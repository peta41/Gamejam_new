using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SharkSelect : MonoBehaviour
{
    public void SelectShark(int sceneIndex)
    {
        SceneManager.LoadScene(5);
    }
}
