using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense
{
    public class TowerDefenseSceneManager : SingletonMonoBehaviour<TowerDefenseSceneManager>
    {
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}