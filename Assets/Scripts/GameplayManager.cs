using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private PauseManager _pauseManager;

    private bool _isPaused;

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!_isPaused);
        }
    }

    private void PauseGame(bool isPaused)
    {
        _isPaused = isPaused;
        _pauseManager.gameObject.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }
}
