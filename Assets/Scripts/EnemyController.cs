﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject deathFxPrefab;

    [SerializeField]
    Transform parent;

    [SerializeField]
    int score = 100;

    private Scoreboard scoreboard;

    private bool hasBeenhit = false;

    void Start()
    {
        var collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;

        scoreboard = FindObjectOfType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!hasBeenhit)
        {
            hasBeenhit = true;

            var obj = Instantiate(deathFxPrefab, transform.position, Quaternion.identity);
            obj.transform.parent = parent;

            scoreboard.ScoreHit(score);

            Destroy(gameObject);
        }
    }
}
