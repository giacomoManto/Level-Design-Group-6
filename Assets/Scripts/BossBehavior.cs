using UnityEngine;
using System.Collections.Generic;

public class BossBehavior : MonoBehaviour
{
    public List<GameObject> dirs;
    public GameObject projectile;
    public GameObject player;
    public float rotSpeed = 5;

    private float shotTimer = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        
        shotTimer += Time.deltaTime;
        if (shotTimer > 2.0f)
        {
            shotTimer = 0.0f;
            foreach (GameObject dir in dirs)
            {
                Instantiate(projectile, dir.transform.position, dir.transform.rotation);
            }
        }
    }
}
