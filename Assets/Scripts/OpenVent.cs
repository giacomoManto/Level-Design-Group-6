using System;
using UnityEditor;
using UnityEngine;

public class OpenVent : MonoBehaviour
{
    public GameObject UI;
    public GameObject Vent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(UI,activeSelf)
        {
            if(input.GetKeyDown(KeyCode.E))
            {
                Box.SetActive(false);
                OpenVent();
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

    void OpenVent()
    {
        
    }
}
