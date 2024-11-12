using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(1);
    }
}