using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private Coroutine _coroutine;

    private int _count = 0;

    private bool _isActive = false;

    public UnityEvent<int> OnValueUpdated = new UnityEvent<int>();

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
            yield return new WaitForSeconds(0.5f);

            _count++;

            OnValueUpdated.Invoke(_count);
        }
    }
}