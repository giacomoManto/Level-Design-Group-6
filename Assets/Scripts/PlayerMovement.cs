using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpHeight = 0.5f;
    public float gravity = -9.81f;
    public Transform cameraPos;

    private float verticalVelocity = 0f;
    private CharacterController controller;
    private bool grounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        grounded = controller.isGrounded;
    }

    private void Update()
    {
        grounded = controller.isGrounded;

        if (grounded && verticalVelocity < 0)
        {
            verticalVelocity = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.transform.rotation * move.normalized;
        controller.Move(move * Time.deltaTime * moveSpeed);

        //Debug.Log(grounded);
        if (Input.GetKey("space") && grounded)
        {
            //Debug.Log("JUMPED");
            verticalVelocity += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraPos.position, cameraPos.forward, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                DoorBehavior door = hitObject.GetComponentInParent<DoorBehavior>();
                if (door != null)
                {
                    door.Toggle();
                }
            }
        }
        verticalVelocity += gravity * Time.deltaTime;
        //Debug.Log(verticalVelocity);
        controller.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }
}
