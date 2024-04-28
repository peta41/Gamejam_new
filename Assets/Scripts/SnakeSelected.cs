using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeSelected : MonoBehaviour
{
    public void SelectSnake(int sceneIndex)
    {
        SceneManager.LoadScene(3);
    }
}
