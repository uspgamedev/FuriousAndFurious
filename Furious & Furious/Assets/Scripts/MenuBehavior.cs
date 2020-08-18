using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject credits;

    public void StartGame()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void LoadCredtis()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void LoadMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

}
