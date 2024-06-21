using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation
{
    public class LoadLearningSpaces : MonoBehaviour
    {
        public static Guid LearningSpaceID;

        [SerializeField]
        ViewLearningSpaceButton _viewLearningSpaceButton;

        // Start is called before the first frame update
        List<string> m_DropOptions = new List<string> { };
        List<Guid> learningSpaceList = new List<Guid> { };
        //This is the Dropdown
        TMP_Dropdown m_Dropdown;

        private ApiClientKiota _apiClient;

        private int previousIndex = -1;

        private async Awaitable GetLearningSpacesListAsync()
        {
            var response = await _apiClient.ListLearningspaces.GetAsync();
            m_DropOptions.Add("Espacios");
            learningSpaceList.Add(Guid.Empty);
            foreach (var learningSpace in response)
            {
                m_DropOptions.Add(learningSpace.LearningSpaceName.Value);
                learningSpaceList.Add(learningSpace.LearningSpaceId.Value.Value);
            }
        }

        async void Start()
        {
            //Fetch the Dropdown GameObject the script is attached to
            m_Dropdown = GetComponent<TMP_Dropdown>();
            //Clear the old options of the Dropdown menu
            m_Dropdown.ClearOptions();

            var requestAdapter = new HttpClientRequestAdapter(
                new AnonymousAuthenticationProvider());
            requestAdapter.BaseUrl = "https://localhost:7168/";
            _apiClient = new ApiClientKiota(requestAdapter);

            await GetLearningSpacesListAsync();

            //Add the options created in the List above
            m_Dropdown.AddOptions(m_DropOptions);

            m_Dropdown.RefreshShownValue();

            // Add a listener for the dropdown value change
            m_Dropdown.onValueChanged.AddListener(delegate {
                GetDropDownValue(m_Dropdown.value);
            });

            // Set the default selected index to the first item
            m_Dropdown.value = 0;
            previousIndex = m_Dropdown.value;
        }

        public void GetDropDownValue(int index)
        {
            // Check if the first option is selected
            if (index == 0)
            {
                // Revert to the previously selected valid index
                m_Dropdown.value = previousIndex;
            }
            else
            {
                // Store the new valid index as the previous index
                previousIndex = index;
                if (index >= 0 && index < learningSpaceList.Count)
                {
                    Guid selectedLearningSpaceId = learningSpaceList[index];
                    _viewLearningSpaceButton.updateValue(selectedLearningSpaceId);
                }
                else
                {
                    Debug.Log("Invalid index selected");
                }
            }
        }
    }
}
