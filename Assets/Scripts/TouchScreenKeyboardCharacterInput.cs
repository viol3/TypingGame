using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenKeyboardCharacterInput : MonoBehaviour
{
    private TouchScreenKeyboard _keyboard;

    private string _lastKeyboardInput;

    public event System.Action<string> OnNewCharacterInput;

    private void Awake()
    {
        _keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
        _lastKeyboardInput = "";
    }

    private void LateUpdate()
    {
        KeyboardNewInputNotifier();
    }

    void KeyboardNewInputNotifier()
    {
        if (_lastKeyboardInput.Length < _keyboard.text.Length)
        {
            string newCharacter = _keyboard.text[_keyboard.text.Length - 1].ToString();
            OnNewCharacterInput?.Invoke(newCharacter);
        }
        _lastKeyboardInput = _keyboard.text;
    }

    public void Clear()
    {
        _keyboard.text = "";
    }
}
