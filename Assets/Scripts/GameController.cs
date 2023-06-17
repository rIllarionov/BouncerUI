using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private ColorRandomizer _colorRandomizer;
    [SerializeField] private TransformRandomizer _transformRandomizer;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SphereController _sphereController;
    [SerializeField] private StepsCounter _stepsCounter;
    [SerializeField] private GameObject [] _canvasColorElements;

    private void Awake()
    {
        SetUiColors();
        _enemiesSpawner.EnemiesSpawn(_colorRandomizer,_transformRandomizer,_canvasColorElements);
        _sphereController.SphereInitialize(_colorRandomizer,_transformRandomizer);
        playerController.PlayerSpawn();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.PlayerMover();
            _stepsCounter.SetSteps();
        }
    }

    private void SetUiColors()
    {
        for (int i = 0; i < _canvasColorElements.Length; i++)
        {
            var colorsSetter = _canvasColorElements[i].GetComponent<ColorHolder>();
            colorsSetter.SetColor(_colorRandomizer.GetColorByIndex(i));
        }
    }
    
}
