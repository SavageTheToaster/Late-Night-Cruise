using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField] private string MainMenu = "mainmenu";

    public void MenuChoosing()
    {
        SceneManager.LoadScene(MainMenu);
    }
}