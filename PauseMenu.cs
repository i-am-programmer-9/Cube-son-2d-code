using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region variables


    public GameObject pausePanel;
    public static bool paused;
    #endregion
    public void PauseTheGame()
    {
        pausePanel.SetActive(true);
        paused = true;
    }
    private void Update()
    {
        if (pausePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResumeTheGame();
            }
            if (Input.GetKeyDown(KeyCode.End))
            {
                Restart();
            }
            if (Input.GetKeyDown(KeyCode.Home))
            {
                MainMenu();
            }
        }
    }
    public void ResumeTheGame()
    {
        paused = false;
        pausePanel.SetActive(false);
    }
    public void Restart()
    {
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        paused = false;
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
