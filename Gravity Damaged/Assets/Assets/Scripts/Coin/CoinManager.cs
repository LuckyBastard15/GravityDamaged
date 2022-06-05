using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints = default;
    [SerializeField] private GameObject _coinPrefab = default;
    [SerializeField] private float _speed = 13;

    void Start()
    {
        CoinMovement();
        InvokeRepeating(nameof(SpawnNewCoin),0.5f,0.5f);
    }

    void SpawnNewCoin()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, _spawnPoints.Length - 1));
        Instantiate(_coinPrefab, _spawnPoints[randomNumber].transform.position, _spawnPoints[randomNumber].transform.rotation);
    }

    private void CoinMovement()
    {
        _coinPrefab.transform.Translate(_speed * Time.deltaTime * Vector3.down);
    }
}
