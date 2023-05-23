using UnityEngine;

/*
Zachary Durick
5/15/2023
Flappy Bird final project
AP Computer Science
*/

public class Pipes : MonoBehaviour
{
    public Transform top;    // Reference to the top Transform of the pipe
    public Transform bottom; // Reference to the bottom Transform of the pipe

    public float speed = 1f; // Speed at which the pipes move to the left
    private float leftEdge;  // The x-coordinate of the left edge of the screen

    private void Start()
    {
        // Calculate the x-coordinate of the left edge of the screen in world space
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Move the entire pipe to the left based on the specified speed and frame time
        transform.position += Vector3.left * speed * Time.deltaTime;

        // If the pipe moves beyond the left edge of the screen, destroy it
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}

