using Ali.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingPanelUI : MonoBehaviour
{
    [SerializeField] private TypingLetterUI _letterPrefab;
    [SerializeField] private RectTransform _letterUIParent;

    List<TypingLetterUI> _currentTypingLetterUIs;

    private string _targetWord;
    private int _wordIndex = 0;
    private bool _completed = false;

    public event System.Action OnAllLettersCompleted;

    private void Awake()
    {
        _currentTypingLetterUIs = new List<TypingLetterUI>();
    }

    public void OnNextLetterInput(string nextLetter)
    {
        if(!nextLetter.Equals(_targetWord[_wordIndex].ToString()))
        {
            return;
        }
        CompleteNext();
    }

    void CompleteNext()
    {
        if(_completed)
        {
            return;
        }
        _currentTypingLetterUIs[_wordIndex].Complete();
        _wordIndex++;
        if(_wordIndex == _currentTypingLetterUIs.Count)
        {
            _completed = true;
            OnAllLettersCompleted?.Invoke();
        }
    }

    void RespawnLetterUIs()
    {
        DestroyCurrentTypingLetters();
        GenerateNewTypingLetterUIs();
    }

    void GenerateNewTypingLetterUIs()
    {
        for (int i = 0; i < _targetWord.Length; i++)
        {
            if(!GameUtility.IsStringLetter(_targetWord[i].ToString()))
            {
                continue;
            }
            TypingLetterUI letterUI = Instantiate(_letterPrefab, _letterUIParent).GetComponent<TypingLetterUI>();
            letterUI.Init();
            letterUI.SetLetter(_targetWord[i].ToString());
            _currentTypingLetterUIs.Add(letterUI);
        }
    }

    void DestroyCurrentTypingLetters()
    {
        for (int i = 0; i < _currentTypingLetterUIs.Count; i++)
        {
            Destroy(_currentTypingLetterUIs[i].gameObject);
        }
        _currentTypingLetterUIs.Clear();
    }

    public void SetWord(string word)
    {
        _targetWord = word;
    }

    public void Reset()
    {
        _wordIndex = 0;
        _completed = false;
        RespawnLetterUIs();
    }
}
