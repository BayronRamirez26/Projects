using NUnit.Framework;
using System;
using System.Collections.Generic;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.LearningArea.Entities;
using UnityEngine;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Presentation.LearningArea.LevelBehaviour
{

    /// <summary>
    /// This is a singleton class that is used to transfer the level key between scenes.
    /// Specifically, it is used to transfer the level key between levels, building and learning spaces.
    /// </summary>
    public class SceneLevelList : MonoBehaviour
    {
        public static SceneLevelList Instance { get; private set; }
        
        /// <summary>
        /// List of levels inside the building
        /// </summary>
        public List<Level> Levels { get; set; }

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
            Levels.Clear();
        }
    }
}
