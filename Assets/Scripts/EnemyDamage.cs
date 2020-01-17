using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoint = 200;
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ProcessHit()
    {
        hitPoint -= 1;
    }
}
