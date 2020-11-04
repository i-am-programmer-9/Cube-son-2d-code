using UnityEngine;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void SelectStage(int stage)
    {
        SceneManager.LoadScene(stage);
    }
}
