using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayableDirector director;
    private PlayerMotor playerMotor;
    private Animator playerAnimator;

    // Reference to the virtual camera for cutscenes.
    public CinemachineVirtualCamera virtualCam;

    // Indicates if the game has started.
    public bool isGameStarted = false;
    // Reference to the player's data scriptable object.
    private DataScriptableObject playerData;

    // Event triggered when the game is over.
    public UnityEvent onGameOverEvent;

    // UI element to display the score.
    [SerializeField] TextMeshProUGUI scoreText;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        // Initialize all references.
        InitializeReferences();
    }

    // Method to start the game.
    public void StartGame()
    {
        // Execute initial logics for starting the game.
        ExecuteInitialLogics();
    }

    // Coroutine to turn off the cutscene camera after a delay.
    IEnumerator TurnOffCutSceneCam()
    {
        // Wait for 4 seconds before changing the camera priority.
        yield return new WaitForSeconds(4f);
        virtualCam.Priority = 12;
    }

    // Method to restart the game by reloading the current scene.
    public void RestartGame()
    {
        // Set the time scale back to normal.
        Time.timeScale = 1f;
        // Reload the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    // Method to execute logic when the game is over.
    public void OnGameOver()
    {
        // Invoke the game over event to display the game over panel.
        onGameOverEvent?.Invoke();
        // Display the player's score.
        scoreText.text = playerData._score.ToString();
        // Pause the game.
        Time.timeScale = 0;
    }

    #region INITIAL_LOGICS

    // Method to execute initial logics for starting the game.
    void ExecuteInitialLogics()
    {
        // Add a listener for the game over event.
        GameEvents.GameOver += OnGameOver;
        // Set the game started flag to true.
        isGameStarted = true;
        // Play the director (timeline).
        director.Play();
        // Indicate that the cutscene is complete for the player motor.
        playerMotor._isCutsceneComplete = true;
        // Trigger the start animation for the player.
        playerAnimator.SetBool("start", true);
        // Start the coroutine to turn off the cutscene camera.
        StartCoroutine(TurnOffCutSceneCam());

   

    }
    #endregion

    #region REFERENCES

    // Method to initialize all required references.
    void InitializeReferences()
    {
        // Find the PlayableDirector in the scene.
        director = FindAnyObjectByType<PlayableDirector>();
        // Find the player motor component on the player object.
        playerMotor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
        // Find the animator component on the player object.
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        // Find the player's data scriptable object.
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>().playerData;
    }
    #endregion
}
