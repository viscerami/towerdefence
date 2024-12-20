using enemy;
using Player;
using Scene;
using System;
using UnityEngine;
using TMPro;

namespace Tutor
{
  public class TutorText : MonoBehaviour
  {
    private int _text;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private GameObject mainScroll;
    [SerializeField] private GameObject miniScroll;
    [SerializeField] private TextMeshProUGUI scrollText;
    [SerializeField] private TowerManager tower;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject groundTower;
    [SerializeField] private GameObject flyTower;
    [SerializeField] private GameObject goldTower;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private GameObject castleMonster;
    [SerializeField] private EnemyHealth flyMonster;
    [SerializeField] private EnemyHealth groundMonster;

    private void Start()
    {
      upgrade.SetActive(false);
      //groundTower.SetActive(false);
      //flyTower.SetActive(false);
      //goldTower.SetActive(false);
      tower.OnTowerBuilt += Scroll;
    }

    void Update()
    {
      if (Input.GetMouseButtonDown(0)&&_text!=2 &&_text!=6 &&_text!=7&&_text!=9 &&_text!=8)
      {
        _text++;
      }
      Text(_text);
    }

    private void Text(int text)
    {
      if (text == 0)
      {
        uiText.text = "Я чую демонов, чувствую не к добру это!";
      }
      if (text == 1)
      {
        uiText.text = "Как же мне защитить эти земли от демонов?";
      }
      if (text == 2)
      {
        button.SetActive(true);
        uiText.text = "что это?";
      }
      if (text == 3)
      {
        button.SetActive(false);
        mainScroll.SetActive(true);
      }
      if (text == 4)
      {
        mainScroll.SetActive(false);
        uiText.text = "я готов служить своему Господню.";
      }
      if (text == 5)
      {
        castleMonster.SetActive(true);
        miniScroll.SetActive(true);
        scrollText.text = "Видишь этого демона? Он почти разрушил замок!";
        uiText.text = "Господь, что мне сделать?";
      }
      if (text == 6)
      {
        groundMonster.gameObject.SetActive(true);
        castleMonster.SetActive(false);
        groundTower.SetActive(true);
        scrollText.text = "Возведи башню! Она поможет с порожедниями ада!";
        Time.timeScale = 0f;
        uiText.text = "С благословением!";
      }
      if (text == 7)
      {
        if (groundMonster.currentHealth <= 0)
        {
          groundTower.SetActive(false);
          goldTower.SetActive(true);
          scrollText.text = "Для постройки башен нужно золото! Возведи амбар.";
          uiText.text = "Да будет так."; 
        }
      }
      if (text == 8)
      {
        flyMonster.gameObject.SetActive(true);
        goldTower.SetActive(false);
        flyTower.SetActive(true);
        scrollText.text = "Новый демон! Старашя башня бессильна перед ним. Возведи новую башню!";
        Time.timeScale = 0f;
        uiText.text = "Достойно.";
      }
      if (text == 9)
      {
          flyTower.SetActive(false);
          upgrade.SetActive(true);
          Debug.Log("запуск апа");
          scrollText.text = "Превосходно! Но нам нужны более сильные башни для новых врагов!";
          uiText.text = "как мне это сделать?";
      }
      if (text == 10)
      {
        Debug.Log("запуск башни");
        groundTower.SetActive(true);
        scrollText.text = "Используй свою внутреннюю веру к выбранной башне и та станет сильнее!";
        uiText.text = "Моя вера сильна!";
      }
      if (text == 11)
      {
        scrollText.text = "Теперь ты знаешь все мои тайны. Защити эти земли!";
        uiText.text = "Да благословить меня ваша сила!!";
      }
      if (text == 12)
      {
        PlayerPrefs.SetInt("HasCompletedTutorial", 1); 
        PlayerPrefs.Save(); 
        sceneChanger.MainMenu();
      }
    }

    public void Scroll()
    {
      Time.timeScale = 1f;
      _text++;
    }
    
  }
}
  

