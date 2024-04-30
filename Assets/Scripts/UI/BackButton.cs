using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSelectMenu : MonoBehaviour
{
    //public void GoBackArrow()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //posune v listu build scenu na predchozi aka MainMenu
    //}
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(0);
    }
}
