using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI deathCounterText;
    public int score = 0;
    int deathCounter;
    int totalScoreDeducted;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddDeathCount()
    {
        Debug.Log("Death Added");
        deathCounter++;
        deathCounterText.text = $"Deaths: {deathCounter}";
    }
    public void ScoreUpdate(int scoreAdd)
    {
        Debug.Log("score added");
        score += scoreAdd;
        scoreText.text = $"Score: {score}";
    }
    public void DeductScorePercentage(float percentage)
    {
        int scoreDeduction = Mathf.FloorToInt(score * percentage);
        score -= scoreDeduction;
        totalScoreDeducted += scoreDeduction;
        scoreText.text = $"Score: {score}";
    }
    private void OnEnable()
    {
        Collectable.collectableEvent += ScoreUpdate;
    }
    private void OnDisable()
    {
        Collectable.collectableEvent -= ScoreUpdate;
    }
    public int GetTotalScoreDeducted()
    {
        return totalScoreDeducted;
    }
}