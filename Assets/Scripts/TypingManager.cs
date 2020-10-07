using Ali.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingManager : LocalSingleton<TypingManager>
{
    [SerializeField] private TypingPanelUI _typingPanel;

    public event System.Func<string> RetrieveNewWord;
    public event System.Action OnWordFinished;
    void Start()
    {
        _typingPanel.OnAllLettersCompleted += TypingPanel_OnAllLettersCompleted;
        PrepareNewWord();
        _typingPanel.Reset();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if(GameUtility.GetPressedKey() != KeyCode.None)
        {
            OnLetterInput(GameUtility.GetPressedKey().ToString());
        }
    }
#endif
    private void TypingPanel_OnAllLettersCompleted()
    {
        Invoke("PrepareNewWord", 0.5f);
        OnWordFinished?.Invoke();
    }

    void PrepareNewWord()
    {
        if (RetrieveNewWord != null)
        {
            _typingPanel.SetWord(RetrieveNewWord.Invoke());
        }
        else
        {
            _typingPanel.SetWord("HELLO");
        }
        _typingPanel.Reset();
    }

    public void OnLetterInput(string letter)
    {
        _typingPanel.OnNextLetterInput(letter.ToUpper());
    }
}
