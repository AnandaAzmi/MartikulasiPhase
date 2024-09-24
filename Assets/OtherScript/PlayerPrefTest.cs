using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        SaveData("ElKecepatan", 10, 990f);
        LoadData();
    }

    
    void SaveData(string nickname, int level, float score)
    {
        PlayerPrefs.SetString("nickName", nickname);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetFloat("score", score);
        Debug.Log("Save Success");
    }
    void LoadData()
    {
        string nick = PlayerPrefs.GetString ("nickName", "nicknameTidak ada");
        int level = PlayerPrefs.GetInt("level", 0);
        float score = PlayerPrefs.GetFloat("score", 1f);
        Debug.Log(nick);
        Debug.Log(level);
        Debug.Log(score);
    }
}
