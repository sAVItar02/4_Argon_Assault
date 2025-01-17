﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 20;

    [SerializeField] int hitPoints = 10;
    // Start is called before the first frame update
    ScoreBoard scoreBoard;
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddNonTriggerBoxCollider();   
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider EnemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        EnemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hitPoints--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
