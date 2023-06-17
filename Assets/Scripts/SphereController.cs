using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;
    private GameObject _currentSphere;
    private ColorRandomizer _colorRandomizer;
    private TransformRandomizer _transformRandomizer;

    private Sphere _sphere;
    
    public void SphereInitialize(ColorRandomizer colorRandomizer, TransformRandomizer transformRandomizer)
    {
        if (_currentSphere!=null)
        {
            Destroy(_currentSphere);
        }
        
        _transformRandomizer = transformRandomizer;
        _colorRandomizer = colorRandomizer;
        
        _currentSphere = Instantiate(_spherePrefab, _transformRandomizer.GetCoordinate(),Quaternion.identity);
        
        var renderer = _currentSphere.GetComponent<Renderer>();
        renderer.material.color = _colorRandomizer.GetColor();

        _sphere = _currentSphere.GetComponent<Sphere>();
        _sphere.PlayerTouch += RecolorObject;
    }

    private void RecolorObject(GameObject gameObject)
    {
        
        var playerRenderer = gameObject.GetComponent<Renderer>();
        var sphereColor = _currentSphere.GetComponent<Renderer>().material.color;
        playerRenderer.material.color = sphereColor;
        
        _sphere.PlayerTouch -= RecolorObject;
        SphereInitialize(_colorRandomizer,_transformRandomizer);
    }

    private void OnDestroy()
    {
        _sphere.PlayerTouch -= RecolorObject;
    }
}
