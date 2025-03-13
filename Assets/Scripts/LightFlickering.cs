using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    public List<GameObject> lights;
    
    private float timer;
    private bool active = true;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            active = !active;
            
            foreach (GameObject light in lights)
            {
                light.SetActive(active);
            }

            if (active)
            {
                timer = Random.Range(0.5f, 8.0f);
            }
            else
            {
                timer = Random.Range(0.01f, 0.25f);
            }
        }
    }
}
