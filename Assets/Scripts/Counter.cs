using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _counterUI;

    private Coroutine _countingCoroutine;

    private int _count;

    private bool _isCounting;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounting();
            }
            else
            {
                StartCounting();
            }
        }
    }

    private void StartCounting()
    {
        _isCounting = true;
        _countingCoroutine = StartCoroutine(CountEveryHalfSecond());
    }

    private void StopCounting()
    {
        _isCounting = false;
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }
    }

    private IEnumerator CountEveryHalfSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _count++;
            UpdateCounterDisplay();
        }
    }

    private void UpdateCounterDisplay()
    {
        Debug.Log("Current count: " + _count);

        _counterUI.text = "Count: " + _count;
    }
}
