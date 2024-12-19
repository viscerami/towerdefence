using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        private bool _paused = false;
        [SerializeField] private GameObject levelPanel;

        private void Start()
        {
            levelPanel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        public void LevelSetUp()
        {
            if (PlayerPrefs.GetInt("HasCompletedTutorial", 0)==0)
            {
                Tutor();
            }
            else
            {
                levelPanel.SetActive(true);
            }
        }

        public void Pause()
        {
            _paused = !_paused;

            if (_paused)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
            }
        }

        public void Tutor()
        {
            SceneManager.LoadScene(1);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void Level1()
        {
            SceneManager.LoadScene(2);
        }
        public void Level2()
        {
            SceneManager.LoadScene(3);
        }
        public void Level3()
        {
            SceneManager.LoadScene(4);
        }
        
        public void CloseMenu()
        {
            levelPanel.SetActive(false);
        }
        
        public void Quit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}