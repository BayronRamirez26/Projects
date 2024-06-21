using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;


namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure
{
    public class UserSpawner : MonoBehaviour
    {
        // The following fields will be editable from the Unity Editor
        [SerializeField]
        // Template used for the user prefab
        private GameObject _userPrefab;

        [SerializeField]
        // Amount of space between spawn of users
        private float _offset;
        // Start is called before the first frame update
        void Start()
        {
            //SpawnUsers(new List<LearningSpaces>
            //{
            //    new LearningSpaces
            //    {
            //        LearningSpaceId = new GuidWrapper
            //        {
            //            Value = Guid.NewGuid()
            //        },
            //        LearningSpaceName = new ShortName
            //        {
            //            Value = "Learning Space 1"
            //        }
            //    },

            //    new LearningSpaces
            //    {
            //        LearningSpaceId = new GuidWrapper
            //        {
            //            Value = Guid.NewGuid()
            //        },
            //        LearningSpaceName = new ShortName
            //        {
            //            Value = "Learning Space 2"
            //        }
            //    }

            //}); 

        }

        // Update is called once per frame
        void Update()
        {
        
        }
        // TODO: Do it but with DTOs for the LearningSpaces
        public void SpawnUsers(List<ThemePark_UCR.Infrastructure.ApiClient.Client.Models.LearningSpaces> learningSpaces)
        {
            float currentOffset = 0;
            foreach (var learningSpace in learningSpaces)
            {
                var userPosition = transform.position + new Vector3(currentOffset, 0);
                var userGameObject = Instantiate(_userPrefab, userPosition, transform.rotation);

                var userTextMeshPro = userGameObject.GetComponentInChildren<TextMeshProUGUI>();
                userTextMeshPro.text = learningSpace.LearningSpaceName.Value;

                currentOffset += _offset;
            }
        }
    }
}
