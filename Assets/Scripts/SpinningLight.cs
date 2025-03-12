using UnityEngine;

public class SpinningLight : MonoBehaviour
{
    public float RotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), RotationSpeed * Time.deltaTime);
    }
}
