using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    // Listen to walls, walls speak.
    private List<Brick> remainingBricks = new List<Brick>();

    [SerializeField] GameObject winScreen;

    //void OnEnable()
    //{
    //    Brick.OnBrickDestroyed += HandleBrickDestroyed;
    //}
    //void OnDisable()
    //{
    //    Brick.OnBrickDestroyed -= HandleBrickDestroyed;
    //}

    void Start()
    {
        remainingBricks.AddRange(FindObjectsByType<Brick>(FindObjectsSortMode.None));
        if (winScreen != null) winScreen.SetActive(false);
    }

    private void HandleBrickDestroyed(Brick brick)
    {
        remainingBricks.Remove(brick);

        if (remainingBricks.Count == 0)
        {
            Debug.Log("Mambo ! You win");
            Time.timeScale = 0.001f;
            if (winScreen != null) winScreen.SetActive(true);
        }
    }
}
