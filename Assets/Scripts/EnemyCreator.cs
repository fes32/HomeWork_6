using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Enemy _templay;
    [SerializeField] private Transform _path;

    private Transform[] _spawnPoints;
    private int _currenSpawnPoint;

    private void OnEnable()
    {
        _spawnPoints = new Transform[_path.childCount];

        for(int i=0; i<_path.childCount; i++)
        {
            _spawnPoints[i] = _path.GetChild(i); 
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (isActiveAndEnabled)
        {
            if (_currenSpawnPoint >= _path.childCount)
            {
                _currenSpawnPoint = 0;
            }
            else
            {
                Enemy enemy = Instantiate(_templay, _spawnPoints[_currenSpawnPoint].transform.position, Quaternion.identity);

                _currenSpawnPoint++;

                yield return new WaitForSeconds(2f);
            }
        }
    }
}