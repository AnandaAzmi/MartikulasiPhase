using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShooterManager : MonoBehaviour
{
    public static GameShooterManager instance;
    public float score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this);
        }
    }
}
