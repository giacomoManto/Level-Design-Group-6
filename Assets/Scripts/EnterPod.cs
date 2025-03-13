using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPod : MonoBehaviour
{
    public GameObject UI;

    public GameObject WinUI;

    public GameObject Player;

    public Vector3 PlayerPos;
    
    bool isPlaying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = true;
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
        UI.SetActive(false);
        WinUI.SetActive(true);
        Invoke("LoadScene", 3);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
