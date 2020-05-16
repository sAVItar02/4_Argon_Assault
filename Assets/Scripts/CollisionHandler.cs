using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject explosion; 
    private void OnTriggerEnter(Collider other)
    {
        startDeathSequence();
        explosion.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    void startDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
