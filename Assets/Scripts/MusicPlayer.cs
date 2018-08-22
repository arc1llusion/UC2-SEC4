using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        var players = FindObjectsOfType<MusicPlayer>().Length;
        if (players > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Use this for initialization
    void Start()
    {
    }
}
