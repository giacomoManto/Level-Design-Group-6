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

    private float vertRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
            print("hello!");
            yVelocity = jumpVelocity;
        }

        Vector3 velocity = (move + new Vector3(0, yVelocity, 0)) * Time.deltaTime;
        
        controller.Move(velocity);
        
        yVelocity -= 0.5f * gravity * Time.deltaTime;
        
        if (Input.GetKeyDown("left ctrl"))
        {
            controller.height = 0.625f;
            cameraTransform.localPosition.Set(0, -0.625f, 0);
            transform.Translate(0, -0.5625f, 0);
        }
        if (Input.GetKeyUp("left ctrl"))
        {
            controller.height = 1.75f;
            cameraTransform.localPosition.Set(0, 0.75f, 0);
            transform.Translate(0, 0.5625f, 0);
        }
    }
}
