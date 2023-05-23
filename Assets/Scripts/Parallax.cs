using UnityEngine;
/*
Zachary Durick
5/15/2023
Flappy Bird final project
AP Computer Science
*/

public class Parallax : MonoBehaviour
{
    //parallax refers to a visual effect that creates an illusion of depth by moving different layers of a scene at different speeds
    private MeshRenderer meshRenderer;  
    public float animationSpeed = 1f;    // Speed at which the parallax effect should animate

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();   // Get the MeshRenderer component attached to this GameObject
    }

    private void Update()
    {
        // Update the offset of the main texture of the material attached to the MeshRenderer
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}

