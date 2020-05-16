using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPLayer : MonoBehaviour
{
    private void Awake()
    {
        int numberOfMusicPlayers = FindObjectsOfType<MusicPLayer>().Length;

        if(numberOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
