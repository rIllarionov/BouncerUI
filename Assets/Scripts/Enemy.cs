using System;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private WinnerScreenController _winnerScreenController;
    
    private GameObject _colorField;
    private TextMeshProUGUI _text;
    
    private Color _enemyColor;

    private void Start()
    {
        _enemyColor = GetComponent<Renderer>().material.color;
        _winnerScreenController = FindObjectOfType<WinnerScreenController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        var playerColor = other.gameObject.GetComponent<Renderer>().material.color;

        if (_enemyColor==playerColor)
        {
            ReportOnDie();
            Destroy(transform.gameObject);
            _winnerScreenController.WinnerCheck();
        }
    }

    public void ReportColor(GameObject colorField)
    {
        _colorField = colorField;
        _text = _colorField.GetComponentInChildren<TextMeshProUGUI>();
        var enemiesCurrentCount = Convert.ToInt32(_text.text);
        enemiesCurrentCount++;
        _text.text = enemiesCurrentCount.ToString();
    }

    private void ReportOnDie()
    {
        var enemiesCurrentCount = Convert.ToInt32(_text.text);
        enemiesCurrentCount--;
        _text.text = enemiesCurrentCount.ToString();
    }
}