using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            Debug.Log("Finish");
            Destroy(gameObject);
        }
    }
}
