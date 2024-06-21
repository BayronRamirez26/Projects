using System.Collections.Generic;
using TMPro;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteBehaviour;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteMenu
{
    public class SiteDropdownLoader : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _siteDropdown;

        [Inject]
        private IEventChannel _eventChannel;

        // Start is called before the first frame update
        void Start()
        {
            _eventChannel.Subscribe<FetchSitesFromCampusCascadeEvent>(
                OnFetchSitesFromCampusCascadeEvent);
            // Add listener for when the dropdown value changes
            _siteDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
            _siteDropdown.interactable = false;
        }

        void OnDestroy()
        {
            _eventChannel.Unsubscribe<FetchSitesFromCampusCascadeEvent>(
                OnFetchSitesFromCampusCascadeEvent);
            // Remove listener when this object is destroyed
            _siteDropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
        }


        /// <summary>
        /// This method is called when the FetchCampusesFromUniversityCascadeEvent is fired
        /// and it will create the names in the campus dropdown
        /// </summary>
        /// <param name="event"></param>
        private void OnFetchSitesFromCampusCascadeEvent(
            FetchSitesFromCampusCascadeEvent @event)
        {
            // Clear the existing options
            _siteDropdown.ClearOptions();

            // Add the options created in the List above
            _siteDropdown.AddOptions((List<string>)@event.SiteNames);

            // Optionally, you can also set a default or placeholder option
            _siteDropdown.options.Insert(0, new TMP_Dropdown.OptionData() { text = "Seleccione Finca" });
            _siteDropdown.value = 0;
            _siteDropdown.RefreshShownValue();

            _siteDropdown.interactable = true;

        }

        /// <summary>
        /// This method is called when the value of the dropdown changes
        /// and it will fire the FetchSelectedCampusEvent
        /// </summary>
        /// <param name="index"></param>
        private void OnDropdownValueChanged(int index)
        {
            // Get the name of the selected campus
            string siteName = _siteDropdown.options[index].text;

            // if index is 0, send an empty string
            if (index == 0)
            {
                siteName = "";
            }

            // Set the selected campus name in the SiteDataStore
            SiteDataStore.Instance.SiteName = siteName;

            // Fire the FetchSelectedCampusEvent with the selected campus name
            _eventChannel.Fire(new FetchSelectedSiteEvent(siteName));
        }
    }
}