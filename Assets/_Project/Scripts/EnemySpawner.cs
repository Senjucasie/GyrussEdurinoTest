using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/SpawnEnemy", order = 1)]
public class EnemySpawner : ScriptableObject
{
    public GameObject EnemyPlane;
    
    [Range(0.2f, 10)]
    public float EnemySpawnDelay;

    [Range(2, 10)]
    public int MaxEnemyPlane;

    public float RotationSpeed;

    public float DiameterSpeed;

    public float ScoreMultiplier;

    public Vector3 CenterPoint;
}
