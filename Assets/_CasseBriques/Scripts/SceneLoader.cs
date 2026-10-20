using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class SceneLoader : MonoBehaviour
{
    public bool quitGame = false;
    [Dropdown("SceneValues"), DisableIf(nameof(quitGame))]
    public string sceneValue;
    private List<string> SceneValues
    {
        get
        {
            return new List<string>()
    { "MainMenu", "LaurentScene", "LouiseScene", "D", "E" };
        }
    }


    public void LoadScene()
    {
        if (!quitGame)
        {
            SceneManager.LoadScene(sceneValue);
        }
        else
        {
            Application.Quit();
        }
    }
}
