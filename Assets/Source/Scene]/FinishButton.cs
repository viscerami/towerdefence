using UnityEngine;
using UnityEngine.UI;

namespace Scene
{
    public class FinishButton : MonoBehaviour
    {
        public Button finishTutorialButton;

        private void Start()
        {
            finishTutorialButton.onClick.AddListener(FinishTutorial);
        }

        public void FinishTutorial()
        {
            PlayerPrefs.SetInt("HasCompletedTutorial", 1); 
            PlayerPrefs.Save(); 
        }
    }
}
