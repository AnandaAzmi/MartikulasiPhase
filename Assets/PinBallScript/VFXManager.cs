using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxBumper;

    public void PlayVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxBumper, spawnPosition, Quaternion.identity);
    }
}
