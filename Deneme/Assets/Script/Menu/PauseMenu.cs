using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Canvas2;
    public void PauseButton()
    {
        Canvas2.SetActive(true);
    }

    public void ResumeButton()
    {
        Canvas2.SetActive(false);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }
}
