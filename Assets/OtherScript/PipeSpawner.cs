using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnDelay = 1.5f;
    public float destroyTime = 5f;
    public float minY = -2;
    public float maxY = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawner), 0f, spawnDelay);
    }

    public void Spawner()
    {
        var pipeY = Random.Range(minY, maxY);
        var position = transform.position;
        position.y = pipeY;
        GameObject spawnPipe = Instantiate(pipePrefab, position, Quaternion.identity);
        Destroy(spawnPipe, destroyTime);
    }

}
