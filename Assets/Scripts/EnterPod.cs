using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPod : MonoBehaviour
{
    public GameObject Player;
    public GameObject Pod;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            WinGame();
        }
    }

    void WinGame()
    {
        PlayerMovement.setIsPlaying();
        Player.transform.position = Pod.transform.position;
        Player.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        Invoke("LoadScene", 3);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
