using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingLetterUI : MonoBehaviour
{
    [SerializeField] private Color _completedColor;

    private string _letter;
    private Text _letterText;

    private Color _firstColor;
    private bool _completed = false;

    public void Init()
    {
        _letterText = GetComponent<Text>();
        _firstColor = _letterText.color;
    }

    void UpdateTextUI()
    {
        _letterText.text = _letter;
    }
    public void SetLetter(string letter)
    {
        _letter = letter;
        UpdateTextUI();
    }

    public void Complete()
    {
        if(_completed)
        {
            return;
        }
        _letterText.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f);
        _letterText.color = _completedColor;
        _completed = true;
    }

    public void Reset()
    {
        _letterText.color = _firstColor;
    }
}
