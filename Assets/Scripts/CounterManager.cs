using UnityEngine;

public class CounterManager : MonoBehaviour
{
    [SerializeField] private CounterView _view;

    private void Start()
    {
        var input = gameObject.AddComponent<InputHandler>();
        var counter = gameObject.AddComponent<Counter>();

        input.OnClick.AddListener(counter.ToggleCounting);

        counter.OnValueUpdated.AddListener(_view.UpdateValue);
    }
}