using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WinChecker : MonoBehaviour
{
    // Listen to walls, walls speak.
    [SerializeField] GameObject winScreen;
    [SerializeField] private TMP_Text _screenText;

    public UnityEvent OnWin;

    void Start()
    {
        if (winScreen != null) winScreen.SetActive(false);
    }

    public void WinGame()
    {
        Debug.Log("Mambo ! You win");
        Time.timeScale = 0.001f;
        OnWin?.Invoke();
        _screenText.text = "YOU WIN! :)";
        if (winScreen != null) winScreen.SetActive(true);

    }
}
