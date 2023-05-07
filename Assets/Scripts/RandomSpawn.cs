using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] Enemy;
    public List<Transform> SpawnPoints;
    private int _enemySpawnTime = 2;

    private void Start()
    {
        SpawnPoints = new List<Transform>(SpawnPoints);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < Enemy.Length; i++)
        {
            var spawn = Random.Range(0, SpawnPoints.Count);
            Instantiate(Enemy[i], SpawnPoints[spawn].transform.position, Quaternion.identity);
            SpawnPoints.RemoveAt(spawn);
            yield return new WaitForSeconds(_enemySpawnTime);
        }
    }
}
