using System.Collections;
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
    private AudioSource source;
    private bool AudioPlayed=false;
    private void Start()
    {
        //Ininitalize all References
        References();
   
    }

    void Update()
    {
        // Follow the player with an offset
        if (gameManager.isGameStarted)
        {
            animator.SetBool("Run", true);
            Vector3 targetPosition = playerTransform.position + playerTransform.TransformDirection(offset);
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;


            if (!AudioPlayed)
            {
                source.Play();
                AudioPlayed = true;
                StartCoroutine(AudioPlayDeley());
            }
        }

    }

    IEnumerator AudioPlayDeley()
    {
        yield return new WaitForSeconds(20f);
        AudioPlayed=false;
    }


    #region REFERENCES

    void References()
    {
        animator = GetComponent<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();    
        source = GetComponent<AudioSource>();
    }
    #endregion
}
