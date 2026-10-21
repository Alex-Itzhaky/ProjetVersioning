using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class SceneLoader : MonoBehaviour
{
    [DisableIf(nameof(HasStuffToShow))]
    public bool quitGame = false;
    [Dropdown("SceneValues"), DisableIf(nameof(ShouldDisableSceneValue))]
    public string sceneValue;
    private bool HasStuffToShow => _showStuff != null;
    private bool ShouldDisableSceneValue => quitGame || HasStuffToShow;
    [DisableIf(nameof(quitGame))]
    public GameObject _showStuff;

    private List<string> SceneValues
    {
        get
        {
            return new List<string>()
    { "MainMenu", "LaurentScene", "LouiseScene", "D", "E" };
        }
    }

    void Start()
    {
        if (_showStuff != null) _showStuff.SetActive(false);
    }
    public void LoadScene()
    {
        if (!quitGame && !HasStuffToShow)
        {
            SceneManager.LoadScene(sceneValue);
        }
        else if (!HasStuffToShow)
        {
            Application.Quit();
        }
        else
        {
            ShowTheStuff();
        }
    }

    void ShowTheStuff()
    {
        if (_showStuff != null)
        {
            _showStuff.SetActive(true);
        }
    }
}
