using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //posune v listu build scenu na dalsi aka WeaponSelect
    }

    public void QuitGame()
    {
        Application.Quit();    
    }
    public void OptionsGo(int sceneIndex)
    {
        SceneManager.LoadScene(6);
    }
}
