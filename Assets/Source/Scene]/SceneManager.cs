using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneChanger : MonoBehaviour
    {
        public void PlayGame(string sceneName)
        {
            SceneManager.LoadScene(1);
        }
    }
}