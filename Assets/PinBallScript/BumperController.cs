using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiple;
    public Color color;

    private Renderer renderer;
    private Animator animator;
    public void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();    
        renderer.material.color = color;
        
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider == bola)
        {
            Rigidbody rbBola = bola.GetComponent<Rigidbody>();
            rbBola.velocity *= multiple;
            animator.SetTrigger("hit");
        }
    }
}
