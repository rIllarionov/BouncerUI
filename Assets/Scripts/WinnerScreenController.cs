using System;
using TMPro;
using UnityEngine;

public class WinnerScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _redField;
    [SerializeField] private TextMeshProUGUI _greenField;
    [SerializeField] private TextMeshProUGUI _yellowField;
    [SerializeField] private GameObject _winnerScreen;
    public void WinnerCheck()
    {
        var red = Convert.ToInt32(_redField.text);
        var green = Convert.ToInt32(_greenField.text);
        var yellow = Convert.ToInt32(_yellowField.text);

        var sum = red + green + yellow;

        if (sum==0)
        {
            _winnerScreen.SetActive(true);
        }
    }
}
