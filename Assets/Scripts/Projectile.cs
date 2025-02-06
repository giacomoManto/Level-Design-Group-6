using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 3.0f;

    public Collider hitbox;

    private float deathTimer = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        deathTimer += Time.deltaTime;
        if (deathTimer > 5.0)
        {
            Destroy(this.gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        
    }
}
