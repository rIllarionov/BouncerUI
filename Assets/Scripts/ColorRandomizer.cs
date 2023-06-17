using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private List <Color> _availableColors;

    public Color GetColor()
    {
        var randomIndex = Random.Range(0, _availableColors.Count);
        return _availableColors[randomIndex];
    }

    public Color GetColorByIndex(int index)
    {
        return _availableColors[index];
    }
}