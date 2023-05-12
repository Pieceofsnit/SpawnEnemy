using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _gangEnemies;
    [SerializeField] private List<Transform> _spawnPoints;

    private int _delay = 2;

    private void Start()
    {
        _spawnPoints = new List<Transform>(_spawnPoints);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var spawn = Random.Range(0, _spawnPoints.Count);
        var waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _gangEnemies.Count; i++)
        {
            Instantiate(_gangEnemies[i], _spawnPoints[spawn].transform.position, Quaternion.identity);
            _spawnPoints.RemoveAt(spawn);
            yield return waitForSeconds;
        }
    }
}
