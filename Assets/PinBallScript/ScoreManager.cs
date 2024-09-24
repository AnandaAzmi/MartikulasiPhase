using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public float score;

    void Start()
    {
        ResetScore();
    }
    public void AddScore(float addition)
    {
        score += addition;
    }
    public void ResetScore()
    {
        score = 0;
    }
}
