using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("Instantiate")]
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform[] postRotEnemy;
    [SerializeField]
    private float timeBetweenEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("CreateEnemies", timeBetweenEnemies, timeBetweenEnemies);

    }

    private void CreateEnemies()
    {
        int n = Random.Range(0, postRotEnemy.Length);

        Instantiate(enemyPrefab, postRotEnemy[n].position, postRotEnemy[n].rotation);

    }
}
