using Gynuss.Events;
using System.Collections;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField]private GameObject Bullet;

    [SerializeField] private EnemySpawner _enemySpawner;
    
    [SerializeField] private Transform _centerPoint;

    private WaitForSeconds _enemySpawnWait;
    private int maxEnemy;

    private void OnEnable() => EventBroker.FireBullet += SpawnBullet;
    
    private void Start() => StartEnemySpawn();
    
    private void StartEnemySpawn()
    {
        maxEnemy = _enemySpawner.MaxEnemyPlane;
        _enemySpawnWait = new WaitForSeconds(_enemySpawner.EnemySpawnDelay);
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnBullet(Vector3 spawnposition) => Instantiate(Bullet, spawnposition,Quaternion.identity);
    
    private void OnDisable() => EventBroker.FireBullet -= SpawnBullet;
    
    private IEnumerator SpawnEnemies()
    {
        while(maxEnemy>0)
        {
            Instantiate(_enemySpawner.EnemyPlane, _centerPoint.position, Quaternion.identity);
            maxEnemy--;
            yield return _enemySpawnWait;
        }
    }
}
