/*
Zachary Durick
5/22/2023
Flappy Bird final project
AP Computer Science
*/

// Import the necessary Unity Engine and Unity UI libraries
using UnityEngine;
using UnityEngine.UI;

// Define the GameManager class, which inherits from MonoBehaviour
public class GameManager : MonoBehaviour
{
    // Declare private variables
    private Player player;      // Reference to the Player object
    private Spawner spawner;    // Reference to the Spawner object

    // Declare public variables that can be accessed in the Unity Editor
    public Text scoreText;          // Reference to the UI text for displaying the score
    public Text highScoreText;      // Reference to the UI text for displaying the high score
  
    public GameObject playButton;   // Reference to the play button GameObject
    public GameObject gameOver;     // Reference to the game over GameObject

    // Define properties for score and high score
    public int score { get; private set; }       // Integer variable to store the current score
    public int highScore { get; private set; }   // Integer variable to store the high score
    
    public void ChangeTextColor(){
        scoreText.color = Color.red;
        highScoreText.color = Color.black;
        //TimerController.timeCounter = Color.red;
    }
 

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Set the target frame rate of the application to 60 frames per second
        Application.targetFrameRate = 60;

        // Find and assign references to the Player and Spawner objects in the scene
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        // Pause the game initially
        Pause();
    }

    /* Plays the flappy bird game */
    public void Play()
    {
        ChangeTextColor(); // want to make sure our color is red for the score
        TimerController.instance.ChangeTextColor();
        TimerController.instance.BeginTimer();
        
        // Retrieve the high score from the player preferences (saved data), defaulting to 0 if not found
        highScore = PlayerPrefs.GetInt("highscore", 0);
        
        // Reset the current score to 0
        score = 0;
        
        // Update the score and high score UI texts
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();

        // Hide the play button and game over UI
        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Resume the game and enable the player
        Time.timeScale = 1f;
        player.enabled = true;

        // Destroy any existing Pipes objects in the scene
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    /* Method that ends the game, if hit spike, game is over */
    public void GameOver()
    {
        // Show the play button and game over UI
        playButton.SetActive(true);
        gameOver.SetActive(true);

        // Pause the game and disable the player
        Pause();
    }
    
    /* Game starts in pause mode with FAPPY in the middle */
    public void Pause()
    {
        // Pause the game by setting the time scale to 0
        Time.timeScale = 0f;
        player.enabled = false; // Disable the player to prevent input
    }

    /* Method that increases the score by one */
    public void IncreaseScore()
    {
        // Increment the score by 1
        score++;

        // Update the score UI text
        scoreText.text = "Score: " + score.ToString();

        // Check if the current score is higher than the high score
        if (highScore < score)
        {
            // Update the high score and save it to player preferences (saved data)
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}

