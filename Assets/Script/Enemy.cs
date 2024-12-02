using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject deathFX;
    
    [SerializeField] private int scorePerHit = 15;
    [SerializeField] private int hitPoint = 50;

    ScoreBoard scoreBoard;
    GameObject parent;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoint -= 15;
        if(hitPoint <= 0)
        {
            scoreBoard.IncreaseScore(scorePerHit);
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        Destroy(gameObject);
   
    }
}
