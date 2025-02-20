using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupBox : MonoBehaviour
{
    public GameObject UI;
    public GameObject WinUI;
    public GameObject Box;
    bool isPlaying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = true;
        UI.SetActive(false);
        WinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            if(UI.activeSelf)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Box.SetActive(false);
                    WinGame();
                }
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

    void WinGame()
    {
        isPlaying = false;
        PlayerMovement.setIsPlaying();
        WinUI.SetActive(true);
        UI.SetActive(false);
        Invoke("LoadScene", 3);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
