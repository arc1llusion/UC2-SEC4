using System;
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

    [SerializeField]
    int hitsUntilDeath = 10;

    private Scoreboard scoreboard;

    void Start()
    {
        var collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;

        scoreboard = FindObjectOfType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitsUntilDeath <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreboard.ScoreHit(score);
        hitsUntilDeath--;
    }

    void KillEnemy()
    {
        var obj = Instantiate(deathFxPrefab, transform.position, Quaternion.identity);
        obj.transform.parent = parent;

        Destroy(gameObject);
    }
}
