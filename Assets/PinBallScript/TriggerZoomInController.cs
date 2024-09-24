using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomInController : MonoBehaviour
{
    public Collider bola;
    public float length;
    public CameraController cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            cameraController.FollowTarget(bola.transform, length);
        }
    }
}
