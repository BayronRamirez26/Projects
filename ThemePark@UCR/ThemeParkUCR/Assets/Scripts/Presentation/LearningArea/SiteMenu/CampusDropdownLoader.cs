using System.Collections.Generic;
using TMPro;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Utilities.Events;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteBehaviour;
using UnityEngine;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.SiteMenu
{
    public class CampusDropdownLoader : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _campusDropdown;

        [Inject]
        private IEventChannel _eventChannel;

        // Start is called before the first frame update
        void Start()
        {
            _eventChannel.Subscribe<FetchCampusesFromUniversityCascadeEvent>(
                OnFetchCampusesFromUniversityCascadeEvent);
            // Add listener for when the dropdown value changes
            _campusDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }

        void OnDestroy()
        {
            _eventChannel.Unsubscribe<FetchCampusesFromUniversityCascadeEvent>(
                OnFetchCampusesFromUniversityCascadeEvent);
            // Remove listener when this object is destroyed
            _campusDropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
        }

        /// <summary>
        /// This method is called when the FetchCampusesFromUniversityCascadeEvent is fired
        /// and it will create the names in the campus dropdown
        /// </summary>
        /// <param name="event"></param>
        private void OnFetchCampusesFromUniversityCascadeEvent(
            FetchCampusesFromUniversityCascadeEvent @event)
        {
            // Add the options created in the List above
            _campusDropdown.AddOptions((List<string>)@event.CampusNames);
        }

        /// <summary>
        /// This method is called when the value of the dropdown changes
        /// and it will fire the FetchSelectedCampusEvent
        /// </summary>
        /// <param name="index"></param>
        private void OnDropdownValueChanged(int index)
        {

            // Get the name of the selected campus
            string campusName = _campusDropdown.options[index].text;
            
            // if index is 0, send an empty string
            if (index == 0)
            {
                campusName = "";
            }

            // Set the selected campus name in the SiteDataStore
            SiteDataStore.Instance.CampusName = campusName;

            // Fire the FetchSelectedCampusEvent with the selected campus name
            _eventChannel.Fire(new FetchSelectedCampusEvent(campusName));
        }
    }
}