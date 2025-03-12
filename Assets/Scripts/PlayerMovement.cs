using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public float sensitivity;
    public float moveSpeed;
    public float jumpVelocity;
    public float gravity;
    public CharacterController controller;
    private float yVelocity;


    public float crouchScale;

    private float originalScale;
    private bool crouching = false;
    private bool tryingToStand = false;

    private float vertRotation;
    private float ogMoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalScale = this.transform.localScale.y;
        ogMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bool onGround = controller.isGrounded;
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        if (onGround)
        {
            yVelocity = 0;
        }
        else
        {
            yVelocity -= 0.5f * gravity * Time.deltaTime;
        }

        vertRotation -= mouseY * sensitivity;
        vertRotation = Mathf.Max(-90, Mathf.Min(90, vertRotation));
        
        transform.Rotate(Vector3.up, mouseX * sensitivity);
        cameraTransform.localRotation = Quaternion.Euler(vertRotation, 0, 0);

        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 move = transform.transform.rotation * movement.normalized * moveSpeed;
        if (Input.GetKey("space") && onGround)
        {
            yVelocity = jumpVelocity;
        }

        Vector3 velocity = (move + new Vector3(0, yVelocity, 0)) * Time.deltaTime;
        
        controller.Move(velocity);
        
        yVelocity -= 0.5f * gravity * Time.deltaTime;
        
        if (Input.GetKeyDown("left ctrl"))
        {
            crouching = true;
            tryingToStand = false;
        }
        if (Input.GetKeyUp("left ctrl"))
        {
            tryingToStand = true;
        }

        if (crouching)
        {
            
            this.transform.localScale = new Vector3(this.transform.localScale.x, Mathf.Lerp(this.transform.localScale.y, crouchScale, 0.1f), this.transform.localScale.z);
            moveSpeed = ogMoveSpeed / 3;

        }
        else
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, Mathf.Lerp(this.transform.localScale.y, originalScale, 0.05f), this.transform.localScale.z);
            moveSpeed = ogMoveSpeed;
        }

        if (crouching && tryingToStand && !Physics.Raycast(this.transform.position, Vector3.up, originalScale - this.transform.localScale.y))
        {
            tryingToStand = false;
            crouching = false;
        }
    }
}
