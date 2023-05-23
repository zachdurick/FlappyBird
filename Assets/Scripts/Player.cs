/*
Zachary Durick
5/21/2023
Flappy Bird final project
AP Computer Science
*/

using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;   // Reference to the SpriteRenderer component
    public Sprite[] sprites;                  // Array of sprites for animation
    private int spriteIndex;                  // Current index of the sprite array

    public float strength = 10f;               // Strength of the player's jump
    public float gravity = -9.81f;            // Strength of gravity pulling the player down
    public float tilt = 5f;                   // Tilt angle of the player when jumping

    private Vector3 direction;                // Direction of player's movement

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   // Get the SpriteRenderer component attached to this GameObject
    }

    private void Start()
    {
        // Start a repeating invoke of the AnimateSprite() method with a delay of 0.15 seconds and repeat every 0.15 seconds
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        // resets the players position
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        // Check if the space key is pressed or the left mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;   // Set the direction vector to an upward direction multiplied by the strength value
        }

        // Apply gravity to the direction vector and update the player's position based on the direction and time
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the player's rotation based on the direction of movement
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex++;   // Increment the sprite index

        // If the sprite index exceeds the length of the sprite array, wrap it back to zero
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        // If the sprite index is within the valid range, update the sprite of the SpriteRenderer
        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    /* tracks when bird hits spikes */
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with an object tagged as "Obstacle"
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Call the GameOver() method in the GameManager script to handle game over logic
            FindObjectOfType<GameManager>().GameOver();
        }
        // Check if the player collided with an object tagged as "Scoring"
        else if (other.gameObject.CompareTag("Scoring"))
        {
            // Call the IncreaseScore() method in the GameManager script to handle scoring logic
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}

