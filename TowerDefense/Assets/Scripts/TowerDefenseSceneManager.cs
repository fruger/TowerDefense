using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense
{
    public class TowerDefenseSceneManager : SingletonMonoBehaviour<TowerDefenseSceneManager>
    {
        [field:SerializeField]
        private string SceneName { get; set; }

        public void LoadSceneSingle(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}