using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinChecker : MonoBehaviour
{
    // Listen to walls, walls speak.
    [SerializeField] GameObject winScreen;

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
        if (winScreen != null) winScreen.SetActive(true);
    }
}
