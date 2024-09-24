using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreValue;
    // Update is called once per frame
    void Update()
    {
        scoreValue.text = scoreManager.score.ToString();
    }
}
