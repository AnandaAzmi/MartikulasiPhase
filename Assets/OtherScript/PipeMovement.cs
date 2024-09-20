using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveSpeedUp = 1f;
    public float speedDelay = 2f;
    private float speedUPTime;
    private bool hasBeenSpeedUp = false;

    private void Start()
    {
        speedUPTime = speedDelay;
    }
    // Update is called once per frame
    void Update()
    {
        var nextPosition = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        transform.SetLocalPositionAndRotation(nextPosition, transform.rotation);
        if (!hasBeenSpeedUp )
        {
            speedUPTime -= Time.deltaTime;
            if (speedUPTime <= 0 )
            {
                SpeedUp();
            }
        }
    }
    private void SpeedUp()
    {
        moveSpeed += moveSpeedUp;
        hasBeenSpeedUp = true;
    }
}
