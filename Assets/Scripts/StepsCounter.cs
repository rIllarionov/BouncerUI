using TMPro;
using UnityEngine;

public class StepsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _steps;

    private void Start()
    {
        _text.text = _steps.ToString();
    }

    public void SetSteps()
    {
        _steps++;
        _text.text = _steps.ToString();
    }
}
