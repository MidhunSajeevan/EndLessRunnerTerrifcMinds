using UnityEngine;

public class DogMotor : MonoBehaviour
{
    // Speed at which the dog moves
    public float speed = 6f;

    // Offset distance behind the player
    public Vector3 offset = new Vector3(0, 0, -5f);

    private Animator animator;
    private GameManager gameManager;
    private Transform playerTransform;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the tag "Player"
    }

    void Update()
    {
        // Follow the player with an offset
        if (gameManager.IsGameStarted)
        {
            Vector3 targetPosition = playerTransform.position + playerTransform.TransformDirection(offset);
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
