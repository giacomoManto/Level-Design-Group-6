using UnityEngine;
using System.Collections.Generic;

public class BossBehavior : MonoBehaviour
{
    public List<GameObject> dirs;
    public GameObject projectile;
    public GameObject player;
    public float rotSpeed = 5;
    
    public GameObject mainTube;
    public GameObject mainBrokenTube;
    
    public List<GameObject> tubes;
    public List<GameObject> brokenTubes;

    private float shotTimer = 0.0f;
    private float startTimer = 10.0f;
    private float phaseTimer = 20.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0)
        {
            startTimer -= Time.deltaTime;
            if (startTimer < 1)
            {
                mainTube.SetActive(false);
                mainBrokenTube.SetActive(true);
                float scale = 0.125f + (0.375f * (1 - startTimer));
                this.transform.localScale = new Vector3(scale, scale, scale);
                this.transform.position += new Vector3(0, 2.75f * Time.deltaTime, 0);
            }
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        
            shotTimer += Time.deltaTime;
            if (phaseTimer > 0)
            {
                phaseTimer -= Time.deltaTime;
            }
            else
            {
                foreach (GameObject tube in tubes)
                {
                    tube.SetActive(false);
                }

                foreach (GameObject tube in brokenTubes)
                {
                    tube.SetActive(true);
                }
            }
            
            
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
}
