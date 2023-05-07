using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gangEnemies;
    [SerializeField] private List<Transform> _spawnPoints;
    private int _delay  = 2;

    private void Start()
    {
        _spawnPoints = new List<Transform>(_spawnPoints);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < _gangEnemies.Length; i++)
        {
            var spawn = Random.Range(0, _spawnPoints.Count);
            Instantiate(_gangEnemies[i], _spawnPoints[spawn].transform.position, Quaternion.identity);
            _spawnPoints.RemoveAt(spawn);
            yield return new WaitForSeconds(_delay);
        }
    }
}
