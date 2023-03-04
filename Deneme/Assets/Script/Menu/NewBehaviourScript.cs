using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator anims;

    private void Start()
    {
        anims = GetComponent<Animator>();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsButton()
    {
        Debug.Log("Settings girdi");
        anims.SetTrigger("MainMenu");
        anims.SetTrigger("OptionsMenu");
    }

    public void QuitButton()
    {
        Debug.Log("Cýkýldý!!!");
        Application.Quit();
    }
}
