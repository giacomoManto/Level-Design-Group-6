using System;
using UnityEditor;
using UnityEngine;

public class OpenVent : MonoBehaviour
{
    public GameObject UI;
    public GameObject Vent;
    public Vector3 newPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newPos = new Vector3(this.transform.position.x, this.transform.position.y - 0.65f, this.transform.position.z + 0.5f);
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(UI.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                OpenTheVent();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }

    void OpenTheVent()
    {
        GameObject.Destroy(Vent);
        GameObject newVent = Instantiate(Vent, this.transform.position, this.transform.rotation);
        newVent.transform.Translate(Vector3.back * 0.65f);
        newVent.transform.Translate(Vector3.down * 0.7f);
        newVent.transform.Rotate(Vector3.right, 90f);
        
    }
}
