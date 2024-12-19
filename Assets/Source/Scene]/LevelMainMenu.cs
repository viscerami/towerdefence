using UnityEngine;
using UnityEngine.UI;

namespace Scene
{
  public class LevelMainMenu : MonoBehaviour
  {
    [SerializeField] private Button lvl1;
    [SerializeField] private Button lvl2;
    [SerializeField] private Button lvl3;
    private void Start()
    {
      UpdateLevelButtons();
    }

    private void UpdateLevelButtons()
    {
      lvl1.interactable = true;
      lvl2.interactable = PlayerPrefs.GetInt("Level2Unlocked", 0) == 1;
      lvl3.interactable = PlayerPrefs.GetInt("Level3Unlocked", 0) == 1;
    }
  }
}
