using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTypingGameManager : MonoBehaviour
{
    [SerializeField] private TouchScreenKeyboardCharacterInput _touchScreenKeyboardCharacterInput;
    [SerializeField] private TextAsset _wordListFile;

    private string[] _words;
    private int _wordIndex = 0;
    void Awake()
    {
        _touchScreenKeyboardCharacterInput.OnNewCharacterInput += TouchScreenKeyboardCharacterInput_OnNewCharacterInput;
        _words = _wordListFile.text.Split('\n');
        TypingManager.Instance.RetrieveNewWord += TypingManager_RetrieveNewWord;
        TypingManager.Instance.OnWordFinished += TypingManager_OnWordFinished;
    }

    private void TypingManager_OnWordFinished()
    {
        _touchScreenKeyboardCharacterInput.Clear();
    }

    private string TypingManager_RetrieveNewWord()
    {
        if(_wordIndex == _words.Length)
        {
            _wordIndex = 0;
        }
        return _words[_wordIndex++];
    }

    private void TouchScreenKeyboardCharacterInput_OnNewCharacterInput(string letter)
    {
        TypingManager.Instance.OnLetterInput(letter);
    }

}
