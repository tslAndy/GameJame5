using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;

public class Death : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathScreen;
    [SerializeField]
    private GameObject screamer;
    VideoPlayer _videoPlayer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(PlayScreamer());
        }
    }

    IEnumerator PlayScreamer()
    {
        screamer?.SetActive(true);
        _videoPlayer = screamer.GetComponentInChildren<VideoPlayer>();
        _videoPlayer.Play();
        yield return new WaitForSeconds(2.3f);
        screamer.SetActive(false);
        _deathScreen?.SetActive(true);
    }
}
