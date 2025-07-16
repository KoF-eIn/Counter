using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> ValueChanged;

    private Coroutine _coroutine;

    private WaitForSeconds _wait;

    private float Delay = 0.5f;

    private int _value;

    private bool _isActive;

    private void Awake()
    {
        _wait = new WaitForSeconds(Delay);

        GetComponent<InputReader>().MouseClicked += ToggleCounting;
    }

    private void OnDestroy()
    {
        if (TryGetComponent(out InputReader input))
        {
            input.MouseClicked -= ToggleCounting;
        }
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