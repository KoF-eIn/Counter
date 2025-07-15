using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEvent OnClick = new UnityEvent();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick.Invoke();
        }
    }
}
