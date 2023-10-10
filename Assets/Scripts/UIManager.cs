using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void FirstScene()
    {
        SwitchScene(0);
    }

    public void NextScene()
    {
        SwitchScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
