using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LlamaSelected : MonoBehaviour
{
    public void LlamaSelect(int sceneIndex)
    {
        SceneManager.LoadScene(4);
    }
}
