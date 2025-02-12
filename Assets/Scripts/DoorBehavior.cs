using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float rotSpeed = 45.0f;
    private bool open;
    private float yRot = 0;

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            yRot -= Time.deltaTime * rotSpeed;
            if (yRot < -90)
            {
                yRot = -90;
            }
        }
        else
        {
            yRot += Time.deltaTime * rotSpeed;
            if (yRot > 0)
            {
                yRot = 0;
            }
        }
        transform.localRotation = Quaternion.Euler(0, yRot, 0);
    }

    public void Toggle()
    {
        open = !open;
    }
}
