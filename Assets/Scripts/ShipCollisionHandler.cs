using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollisionHandler : MonoBehaviour {
    [SerializeField]
    [Tooltip("In seconds")]
    float levelLoadDelay = 1f;

    [SerializeField]
    [Tooltip("Particle effects prefab on player")]
    GameObject deathEffects;

    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");

        deathEffects.SetActive(true);
        var renderer = meshRenderer.GetComponentInChildren<Renderer>();
        renderer.enabled = false;

        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
