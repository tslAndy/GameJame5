using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private FirstPersonAudio _playerAudio;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        if (_playerAudio != null)
        {
            _playerAudio.PauseAllAudio();
        }
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        if (_playerAudio != null)
        {
            _playerAudio.UnpauseAllAudio();
        }
    }
}
