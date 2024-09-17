using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    [SerializeField]
    private AudioSource _shootSFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _shootSFX.Play();
        }
    }
}
