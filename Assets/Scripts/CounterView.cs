using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();

        _text.text = "0"; 
    }

    public void UpdateValue(int value)
    {
        _text.text = value.ToString();
    }
}