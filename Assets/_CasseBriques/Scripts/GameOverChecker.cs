using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverChecker : MonoBehaviour
{
    // Listen to balls, balls speak. No ball, no child.
    [SerializeField] private List<Ball> activeBalls = new List<Ball>();

    [SerializeField] GameObject loseScreen;

    void OnEnable()
    {
        Ball.OnBallSpawned += RegisterBall;
        Ball.OnBallDied += UnregisterBall;
    }

    void OnDisable()
    {
        Ball.OnBallSpawned -= RegisterBall;
        Ball.OnBallDied -= UnregisterBall;
    }

    void Start()
    {
        if (loseScreen != null) loseScreen.SetActive(false);
    }
    private void RegisterBall(Ball ball)
    {
        if (!activeBalls.Contains(ball))
        {
            activeBalls.Add(ball);
        }
    }

    private void UnregisterBall(Ball ball)
    {
        activeBalls.Remove(ball);

        if (activeBalls.Count == 0)
        {
            Debug.Log("The game is fk over, u so bad");
            SceneManager.LoadScene("MainMenu");
            if (loseScreen != null) loseScreen.SetActive(true);
        }
    }
}