using System.Collections;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Vector3 _movementVector;
    private CharacterController _characterController;
    private float _movementSpeed = 6f;
    private float _gravity = 9.89f;
    private float _jupmHeight = 5f;
    public bool _isCutsceneComplete = false;

    [SerializeField] AnimationClip _slidingClip;

    private Animator  animator;


   
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        SideMovements();
        Jump();
        Sliding();
        _characterController.Move(_movementVector * Time.deltaTime);
    }
    void FixedUpdate()
    {
      
        //Call charecter Movement fuctions
        if(_isCutsceneComplete)
            Movement();
        Gravitaion();
       
        _characterController.Move(_movementVector * Time.deltaTime);
        
    }


    public void Movement()
    {
        //Add movement to the character on forward direction

        _movementVector.z = _movementSpeed;

        // Animations add

        animator.SetBool("running",true);
    }
    public void Gravitaion()
    {
        //Check if the player is grounded or not and add gravity
        if (!_characterController.isGrounded)
        {
            _movementVector.y -= _gravity * Time.deltaTime;
        }
        else
        {
            _movementVector.y += -0.2f;
        }
    }
    public void SideMovements()
    {

        // Add movement in left and right directions

        _movementVector.x = Input.GetAxisRaw("Horizontal") * _movementSpeed;
    }
    public void Jump()
    {
        // Add Jump fuctionalities
        
        if ( Input.GetButton("Jump") &&_characterController.isGrounded)
        {
            animator.SetBool("jump",true) ;
            _movementVector.y = Mathf.Sqrt(_jupmHeight);
     
        }
    
    }
    public void Sliding()
    {
        // Add Sliding functionalities
        if(Input.GetKeyDown(KeyCode.DownArrow) && _characterController.isGrounded)
        {
            StartCoroutine(Slide());
        }
    }
    private IEnumerator Slide()
    {
        //Shrink the collider
        Vector3 originalControler = _characterController.center;
        Vector3 newControler  = originalControler;
        _characterController.height /= 2f;
        newControler.y -= _characterController.height / 2f;
        _characterController.center = newControler;

        animator.SetTrigger("slide");

        // Wait until the animation is complete
        yield return new WaitForSeconds(_slidingClip.length);
        

        // Animation is complete  set the controler back to normal
        _characterController.height *= 2f;
        _characterController.center = originalControler;
  
    }
  
  
}
