using Gynuss.Events;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    int _score=0;

    private void Update() => Move();
    
    private void Move()
    {
        transform.RotateAround(_enemySpawner.CenterPoint, Vector3.back, _enemySpawner.RotationSpeed * Time.deltaTime);
        transform.Translate((Vector3.down * _enemySpawner.DiameterSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider collider)
    {
        IInteractableBullet interactableBullet = collider.GetComponent<IInteractableBullet>();
        if(interactableBullet!=null)
        {
            _score = CalculateScore();
            EventBroker.CallAdScore(_score);
            interactableBullet.HideBullet();
            Destroy(gameObject);
        }
    }

    private int CalculateScore()
    {
        float distance = Vector2.Distance(transform.position, Vector2.up);
        float scoreratio =Mathf.Clamp( Mathf.InverseLerp(3.0f, 0.1f, distance),0.1f,1);
        return Mathf.RoundToInt( scoreratio * _enemySpawner.ScoreMultiplier);
    }
}
