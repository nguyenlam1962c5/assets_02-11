using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int xSpawn;
    public int zSpawn;
    public int maxSpawn;
    public float timeDelay =3f ;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < maxSpawn; i++)
        {

            Vector3 spawnPosition = new Vector3(xSpawn, 2, zSpawn);

            int randomIndex = Random.Range(0, enemyPrefabs.Length);


            Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(timeDelay);
        }
    }
}
