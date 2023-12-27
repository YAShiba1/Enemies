using System.Collections;
using UnityEngine;

public class RandomEnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _point;
    [SerializeField] private Transform[] _targets;

    private Transform[] _points;
    //private Transform[] _targets;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForTwoSeconds = new WaitForSeconds(2f);

        for (int i = 0; i < _points.Length; i++)
        {
            yield return waitForTwoSeconds;

            Enemy enemy = Instantiate(_enemy, _points[_currentPoint].position, Quaternion.identity);

            _currentPoint++;

            enemy.SetTarget(_targets[i]);
            enemy.ChaseTarget();

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
