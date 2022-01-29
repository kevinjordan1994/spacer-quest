using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas = null;
    [SerializeField] GameObject howToPlayCanvas = null;
    [SerializeField] float sceneLoadDelay = 2f;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("Game Over Screen", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game");
        Application.Quit();
    }

    public void ViewHowToPlay()
    {
        {
            mainMenuCanvas.SetActive(false);
            howToPlayCanvas.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        {
            howToPlayCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
