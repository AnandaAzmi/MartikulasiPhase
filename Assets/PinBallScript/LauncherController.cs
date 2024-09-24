using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Color changeColor;
    public Color originalColor;
    public Renderer objectRenderer;
    private bool isHold = false;
    [SerializeField] private KeyCode input;
    [SerializeField] private Collider bola;
    [SerializeField] private float maxForce;
    [SerializeField] private float maxTimeHold;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = originalColor;
    }

    private void OnCollisionStay(Collision collision)
    {
        ReadInput(bola);
    }
    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;
        float timeHold = 0.0f;
        while (Input.GetKey(input))
        {
            float t = timeHold / maxTimeHold;
            objectRenderer.material.color = Color.Lerp(originalColor, changeColor, t);
            force = Mathf.Lerp(0, maxForce, t);
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }
        objectRenderer.material.color = originalColor;
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
    }
}
