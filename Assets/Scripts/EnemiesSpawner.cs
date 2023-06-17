using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private int enemyCount;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _board;
    
    private GameObject[] _canvasColorElements;
    private GameObject _currentEnemy;
    private Color _currentEnemyColor;
    
    public void EnemiesSpawn(ColorRandomizer _colorRandomizer, TransformRandomizer _transformRandomizer,GameObject [] canvasColorElements)
    {
        _canvasColorElements = canvasColorElements;
        
        for (int i = 0; i < enemyCount; i++)
        {
            _currentEnemy = Instantiate(_enemyPrefab, _transformRandomizer.GetCoordinate(),Quaternion.identity);
            var renderer = _currentEnemy.GetComponent<Renderer>();
            _currentEnemyColor = _colorRandomizer.GetColor();
            renderer.material.color = _currentEnemyColor;
            _currentEnemy.transform.SetParent(_board.transform,true);
            
            FindProperField();
        }
    }

    private void FindProperField()
    {
        for (int i = 0; i < _canvasColorElements.Length; i++)
        {
            var colorHolder = _canvasColorElements[i].GetComponent<ColorHolder>();
            var holderColor = colorHolder.GetColor();

            if (holderColor==_currentEnemyColor)
            {
                var enemy = _currentEnemy.GetComponent<Enemy>();
                enemy.ReportColor(colorHolder.gameObject);
            }
        }
    }
}
