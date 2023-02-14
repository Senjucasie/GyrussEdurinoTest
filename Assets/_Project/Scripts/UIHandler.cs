using Gynuss.Events;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private int _currentScore;

    [SerializeField]private Text _scoreDisplayer;

    private void OnEnable() => EventBroker.AddScore += UpdateScore;

    private void UpdateScore(int score)
    {
    _currentScore += score;
    _scoreDisplayer.text = _currentScore.ToString();
    }
    
    private void OnDisable() => EventBroker.AddScore -= UpdateScore;
    
}
