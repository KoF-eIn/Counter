using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();

        _text.text = "0";

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