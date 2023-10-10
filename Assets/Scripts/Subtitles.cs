using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    [Tooltip("The text object for the lines to be written to.")]
    [SerializeField]
    private TextMeshProUGUI _subtitleText;
    [SerializeField]
    private List<string> _lines;
    [SerializeField]
    private bool _playOnStart;
    [SerializeField]
    private float _textCooldown;

    private void Start()
    {
        if (_playOnStart)
        {
            TriggerSubtitles();
        }
    }

    private void TriggerSubtitles()
    {
        int index = 0;
        StartCoroutine(PrintLines(index));
    }

    private IEnumerator PrintLines(int index)
    {
        while (_lines.Count > index)
        {
            _subtitleText.text = _lines[index];
            ++index;
            yield return new WaitForSeconds(_textCooldown);
        }
        _subtitleText.text = string.Empty;
    }
}
