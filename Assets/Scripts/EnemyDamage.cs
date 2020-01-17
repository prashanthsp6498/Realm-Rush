using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoint = 10;
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("I am hit");
        ProcessHit();
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ProcessHit()
    {
        hitPoint -= 1;
        print("CUrrent hit point : " + hitPoint);
    }
}
