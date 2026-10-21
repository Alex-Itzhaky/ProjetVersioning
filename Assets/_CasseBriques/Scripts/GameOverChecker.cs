using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverChecker : MonoBehaviour
{
    // Listen to balls, balls speak. No ball, no child.

    [SerializeField] GameObject loseScreen;
    [SerializeField] BallManager ballManager;

    public UnityEvent OnGameOver;

    void Start()
    {
        ballManager.OnEmptyBallRegistry += RevealLoseScreen;
        if (loseScreen != null) loseScreen.SetActive(false);
    }

    private void OnDestroy()
    {
        ballManager.OnEmptyBallRegistry -= RevealLoseScreen;
    }


    private void RevealLoseScreen()
    {
        if (loseScreen != null) loseScreen.SetActive(true);
        OnGameOver?.Invoke();
    }
    
}