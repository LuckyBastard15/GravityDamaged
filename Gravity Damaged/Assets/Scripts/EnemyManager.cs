using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints = default;
    [SerializeField] private GameObject _enemyPrefab = default;

    void Start()
    {
        StartCoroutine(WaitRespawn());
    }

    void SpawnNewEnemy()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, _spawnPoints.Length - 1));
        Instantiate(_enemyPrefab, _spawnPoints[randomNumber].transform.position, _spawnPoints[randomNumber].transform.rotation);
    }

    private IEnumerator WaitRespawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            SpawnNewEnemy();
            yield return new WaitForSeconds(1);
        }
    }

}

 