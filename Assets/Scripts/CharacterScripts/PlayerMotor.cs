using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Vector3 _movementVector;
    private CharacterController _characterController;
    private float _movementSpeed = 6f;
    private float _gravity = 9.89f;
    private float _jupmHeight = 5f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        
    }

    void FixedUpdate()
    {
        //Call charecter Movement fuctions

        Movement();
        Gravitaion();
        SideMovements();
        Jump();
        _characterController.Move(_movementVector * Time.deltaTime);
        
    }

    public void Movement()
    {
        //Add movement to the character on forward direction

        _movementVector.z = _movementSpeed;

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
            _movementVector.y = _jupmHeight;
        }
    
    }
}
