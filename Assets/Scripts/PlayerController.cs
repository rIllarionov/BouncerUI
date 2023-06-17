using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _board;
    [SerializeField] private float _scalarVelocity = 2;
    private Rigidbody _rigidbody;
    private GameObject _currentPlayer;

    public void PlayerSpawn()
    {
        if (_currentPlayer != null)
        {
            Destroy(_currentPlayer);
        }

        _currentPlayer = Instantiate(_playerPrefab, _board.position, Quaternion.identity);
        _rigidbody = _currentPlayer.GetComponent<Rigidbody>();
    }

    public void PlayerMover()
    {
        var mousePosition = GetMousePosition();
        var launchDirection = CalculateLaunchDirection(mousePosition);
        var startSpeed = CalculateStartSpeed(launchDirection);
        _rigidbody.AddForce(startSpeed, ForceMode.Impulse);
    }

    private void Update()
    {
        if (_currentPlayer != null)
        {
            CheckPlayerPosition();
        }
    }

    private void CheckPlayerPosition()
    {
        var playerY = _currentPlayer.transform.position.y;

        if (playerY < -0)
        {
            _rigidbody.Sleep();
            _rigidbody.WakeUp();
            _currentPlayer.transform.position = new Vector3(0, 3, 0);
        }
    }

    private Vector3 CalculateLaunchDirection(Vector3 mousePosition)
    {
        return mousePosition - _currentPlayer.transform.position;
    }

    private Vector3 CalculateStartSpeed(Vector3 launchDirection)
    {
        return launchDirection * _scalarVelocity;
    }

    private Vector3 GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit info, 60f))
        {
            return info.point;
        }

        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}