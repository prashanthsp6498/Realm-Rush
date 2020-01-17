using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1f, 10f)][SerializeField] float spawningEnemyTime = 2f;
    [SerializeField] EnemyMovement enemy;
    void Start()
    {
        StartCoroutine(StartSpawning());        
    }

    IEnumerator StartSpawning()
    {
        while(true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawningEnemyTime);
        }
    }

}
