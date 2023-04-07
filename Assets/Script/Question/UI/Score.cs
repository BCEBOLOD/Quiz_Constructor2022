using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour, IScore
{
    [SerializeField] private int _scoreBalance;

    public int ScoreBalance => _scoreBalance;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText.text = ScoreBalance.ToString();
    }

    public void AdjustScore(int score)
    {
        _scoreBalance += score;
        if (_scoreBalance < 0)
            _scoreBalance = 0;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        _scoreText.text = ScoreBalance.ToString();
    }
}
