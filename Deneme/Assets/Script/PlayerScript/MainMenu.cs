using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuu;
    public GameObject OptionsMenu;
    private void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OptionsButton()
    {
        MainMenuu.SetActive(false);
        OptionsMenu.SetActive(true);

    }

    private void BackButton()
    {
        MainMenuu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    private void QuitButton()
    {
        Application.Quit();
        Debug.Log("CIKILDI!!!");
    }
}
