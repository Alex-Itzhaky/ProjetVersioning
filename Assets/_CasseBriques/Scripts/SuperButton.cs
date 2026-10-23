using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class SceneLoader : MonoBehaviour
{
    [DisableIf(nameof(HasStuff))]
    public bool quitGame = false;
    [Dropdown("SceneValues"), DisableIf(nameof(ShouldDisableSceneValue))]
    public string sceneValue;
    private bool HasStuff => _showStuff != null || _closeStuff != null;
    private bool ShouldDisableSceneValue => quitGame || HasStuff;
    [DisableIf(nameof(DisableShowStuff))]
    [SerializeField] private GameObject _showStuff;

    [DisableIf(nameof(DisableCloseStuff))]
    [SerializeField] private GameObject _closeStuff;

    private bool DisableShowStuff => quitGame || _closeStuff != null;
    private bool DisableCloseStuff => quitGame || _showStuff != null;

    private List<string> SceneValues
    {
        get
        {
            return new List<string>()
    { "MainMenu", "LaurentScene", "LouiseScene", "D", "SecretScene" };
        }
    }

    void Start()
    {
        if (_showStuff != null) _showStuff.SetActive(false);
        if (_closeStuff != null) _closeStuff.SetActive(false);
    }
    public void LoadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (!quitGame && !HasStuff)
        {
            SceneManager.LoadScene(sceneValue);
            Time.timeScale = 1f;
        }
        else if (!HasStuff)
        {
            Application.Quit();
        }
        else
        {
            ShowOrCloseStuff();
        }
    }

    void ShowOrCloseStuff()
    {
        if (_showStuff != null) _showStuff.SetActive(true);
        if (_closeStuff != null) _closeStuff.SetActive(false);
        Debug.Log("Show or hided");
    }
}
