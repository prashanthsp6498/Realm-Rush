using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange;
    [SerializeField] GameObject bullets;

    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemy = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemy.Length == 0) { return; }
        Transform closestEnemy = sceneEnemy[0].transform;
        foreach (EnemyDamage enemy in sceneEnemy)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform enemyA, Transform enemyB)
    {
        var distanceA = Vector3.Distance(transform.position, enemyA.position);
        var distanceB = Vector3.Distance(transform.position, enemyB.position);
        return (distanceA < distanceB) ? enemyA.transform : enemyB.transform;
    }

    private void FireAtEnemy()
    {
        var distanceToEnemy = Vector3.Distance(targetEnemy.transform.position,
                                                gameObject.transform.position
                                              );
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        bullets.SetActive(isActive);
    }
}
