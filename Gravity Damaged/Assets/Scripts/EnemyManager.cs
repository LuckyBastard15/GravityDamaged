using System.Collections;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _speed = 13;

    void Start()
    {
        StartCoroutine(WaitRespwn());
        EnemyMovement();
    }
    void SpawnNewEnemy()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, _spawnPoints.Length - 1));
        Instantiate(_enemyPrefab, _spawnPoints[randomNumber].transform.position, _spawnPoints[randomNumber].transform.rotation);
    }
    private IEnumerator WaitRespwn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            SpawnNewEnemy();
            yield return new WaitForSeconds(1);
        }
    }
    private void EnemyMovement()
    {
        _enemyPrefab.transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
 