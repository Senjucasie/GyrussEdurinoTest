using Gynuss.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _centerTransform;
    [SerializeField] private Transform _bulletSpawnPos;
    [SerializeField]private float _maxBulletDelay;
    [SerializeField]private float _currentTimer;
    private Vector3 _screenCenter;

    private bool _gameStarted;

    [Range(10,100)]
    [SerializeField] private float _playerSpeed;
   

    void Start() => Initialize();
    

    void Update()
    {
        if (!_gameStarted)
            return;

        MovePlayer();

        BulletTimer();

        FireBullet();
   }

    private void Initialize()
    {
        _screenCenter = _centerTransform.position;
        _currentTimer = _maxBulletDelay;
        _gameStarted = true;
    }

    private void BulletTimer() => _currentTimer += Time.deltaTime;

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
            transform.RotateAround(_screenCenter, Vector3.back, _playerSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.RotateAround(_screenCenter, Vector3.forward, _playerSpeed * Time.deltaTime);
    }

    private void FireBullet()
    {
        if (Input.GetKeyUp(KeyCode.Space) && _currentTimer >= _maxBulletDelay)
        {
            EventBroker.CallFireBullet(_bulletSpawnPos.position);
            _currentTimer = 0;
        }
    }
    
}
