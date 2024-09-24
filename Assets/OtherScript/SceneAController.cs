using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetData("El Kecepatan");
    }

    void SetData(string nickName)
    {
        // Debug.Log(PlayerData.NickName);
        // PlayerData.NickName = nickName;
        Debug.Log(GameShooterManager.instance.score);
        GameShooterManager.instance.score = 100f;
    }
}
