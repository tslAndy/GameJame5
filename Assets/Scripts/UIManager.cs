using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private bool _pausable = true;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _pausable)
        {
            TogglePause(_pauseMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #region SceneFunctions
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

    public void ReloadScene()
    {
        SwitchScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    public void TogglePause(GameObject pauseMenu)
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }
}
