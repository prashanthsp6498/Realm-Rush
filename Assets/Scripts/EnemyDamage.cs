using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoint = 200;
    [SerializeField] GameObject explosionFx;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
            explosionFx.SetActive(true);
        }
    }

    private void ProcessHit()
    {
        hitPoint -= 3;
    }
}
