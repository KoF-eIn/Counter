using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private CounterDisplay _display;

    private Counter _counter;

    private void Awake()
    {
        _counter = GetComponent<Counter>();

        _counter.ValueChanged += _display.UpdateDisplay;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counter.ToggleCounting();
        }
    }
}