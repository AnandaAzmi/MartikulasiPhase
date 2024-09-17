using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx_Trigger : MonoBehaviour
{
   [SerializeField] private Collider floor;
    [SerializeField] private AudioSource sfx;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == floor)
        {
            sfx.Play();
        }
    }
}
