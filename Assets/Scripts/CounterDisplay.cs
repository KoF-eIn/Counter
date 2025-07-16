using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CounterDisplay : MonoBehaviour
{
    private Text _text;

    private Counter _counter;

    private void Awake()
    {
        _text = GetComponent<Text>();

        _text.text = "0";

        _counter = FindObjectOfType<Counter>();

        _counter.ValueChanged += UpdateDisplay;
    }

    private void OnDestroy()
    {
        _counter.ValueChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int value)
    {
        _text.text = value.ToString();
    }
}