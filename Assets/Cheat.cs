using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class Cheat : MonoBehaviour
{
    private const float INPUT_TIME_TO_LIVE = 1.5f;
    [SerializeField]
    private CheatItem[] _cheats;
    private string _currentInput;
    private float _inputTime;
    private void Awake()
    {
        Keyboard.current.onTextInput += OnTextInput;
    }
    private void Update()
    {
        if (_inputTime < 0)
        {
            _currentInput = string.Empty;
        }
        else
        {
            _inputTime -= Time.deltaTime;
        }
    }
    private void OnDestroy()
    {
        Keyboard.current.onTextInput -= OnTextInput;
    }
    private void OnTextInput(char inputChar)
    {
        _currentInput += inputChar;
        _inputTime = INPUT_TIME_TO_LIVE;
        FindAnyCheath();
    }
    private void FindAnyCheath()
    {
        foreach (CheatItem cheatItem in _cheats)
        {
            if (_currentInput.Contains(cheatItem.Name))
            {
                cheatItem.Action.Invoke();
                _currentInput = string.Empty;
                break;
            }
        }
    }
    [Serializable]
    public class CheatItem
    {
        public string Name; 
        public UnityEvent Action;
    }
}
