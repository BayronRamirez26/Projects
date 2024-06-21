using System;
using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.Shared
{

    /// <summary>
    /// This is a singleton class that is used to transfer the level key between scenes.
    /// Specifically, it is used to transfer the level key between levels, building and learning spaces.
    /// </summary>
    public class SceneLevelTransferObject : MonoBehaviour
    {
        public static SceneLevelTransferObject Instance { get; private set; }

        /// <summary>
        /// The level index to choose which level to load, default empty
        /// </summary>
        public Guid LevelKey { get; set; } = Guid.Empty;
        
        /// <summary>
        /// Flag to know if the player is entering the level for the first time
        /// </summary>
        public bool FirstTimeEntering { get; set; } = true;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Resets all data properties to their default values.
        /// </summary>
        public void ResetData()
        {
            LevelKey = Guid.Empty;
            FirstTimeEntering = true;
        }
    }
}
