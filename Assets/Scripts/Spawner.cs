using UnityEngine;
/*
Zachary Durick
5/22/2023
Flappy Bird final project
AP Computer Science
*/

public class Spawner : MonoBehaviour
{
    public GameObject prefab;        //  reusable template or blueprint for creating instances of a GameObject (creates the spikes over and over)
    public float spawnRate = 1f;     // Rate at which to spawn the prefabs
    public float minHeight = -1f;    // Minimum height for the spawned prefabs
    public float maxHeight = 2f;     // Maximum height for the spawned prefabs

    private void OnEnable()
    {
        // Start a repeating invoke of the Spawn() method with a delay of spawnRate and repeat every spawnRate seconds
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Cancel the repeating invoke of the Spawn() method
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Instantiate the prefab at the spawner's position with no rotation
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Adjust the position of the spawned prefab by adding a random value within the specified height range
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}

