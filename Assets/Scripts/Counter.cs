using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Coroutine _coroutine;

    private WaitForSeconds _wait;

    private float Delay = 0.5f;

    private int _value;

    private bool _isActive;

    public event Action<int> ValueChanged;

    private void Awake()
    {
        _wait = new WaitForSeconds(Delay);

        _inputReader.MouseClicked += ToggleCounting;
    }

    private void OnDestroy()
    {
        _inputReader.MouseClicked -= ToggleCounting;
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