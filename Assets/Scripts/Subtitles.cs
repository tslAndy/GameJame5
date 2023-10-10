using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    [Tooltip("The text object for the lines to be written to.")]
    [SerializeField]
    private TextMeshProUGUI _subtitleText;

    [Tooltip("The lines that are going to be displayed in a succession in the subtitles.")]
    [SerializeField]
    private List<string> _lines;

    [Tooltip("Whether the subtitles will play when the game starts or not.")]
    [SerializeField]
    private bool _playOnStart;

    [Tooltip("Cooldown before displaying a new line after the current one, in seconds.")]
    [SerializeField]
    private float _textCooldown;

    private void Start()
    {
        if (_playOnStart)
        {
            TriggerSubtitles();
        }
    }

    public void TriggerSubtitles()
    {
        int index = 0;
        StartCoroutine(PrintLines(index));
    }

    public void AddLine(string line)
    {
        _lines.Add(line);
    }

    // Clears all lines and replaces them with one line
    public void OverwriteLinesWithLine(string line)
    {
        _lines.Clear();
        _lines.Add(line);
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
        _lines.Clear();
    }
}
