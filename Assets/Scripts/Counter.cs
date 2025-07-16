using System;
using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    private const float Delay = 0.5f;

    public event Action<int> ValueChanged;

    private Coroutine _coroutine;

    private WaitForSeconds _wait;

    private int _value;

    private bool _isActive;

    private void Awake()
    {
        _wait = new WaitForSeconds(Delay);
    }

    public void ToggleCounting()
    {
        _isActive = !_isActive;

        if (_isActive)
            _coroutine = StartCoroutine(Counting());
        else if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Counting()
    {
        while (_isActive)
        {
            yield return _wait;

            _value++;

            ValueChanged?.Invoke(_value);
        }
    }
}