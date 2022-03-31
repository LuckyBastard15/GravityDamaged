using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
   
    void Start()
    {
        StartCoroutine(WaitRespwn());
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
}
