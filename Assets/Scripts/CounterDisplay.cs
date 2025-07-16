using UnityEngine;
using UnityEngine.UI;

public class CounterDisplay : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();

        _text.text = "0";
    }

    public void UpdateDisplay(int value)
    {
        _text.text = value.ToString();
    }
}