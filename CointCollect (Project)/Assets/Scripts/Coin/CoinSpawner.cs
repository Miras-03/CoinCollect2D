using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public sealed class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin coin;
    private ObjectPool<Coin> pool;

    private const int minX = -9;
    private const int maxX = 9;

    private void Awake() =>
        pool = new ObjectPool<Coin>(CreateObject, EnableObject, DisableObject, DestroyObject,
            collectionCheck: false,
            maxSize: 10);

    private Coin CreateObject() => Instantiate(coin, transform);

    private void EnableObject(Coin coin) => coin.gameObject.SetActive(true);

    private void DisableObject(Coin coin) => coin.gameObject.SetActive(false);

    private void DestroyObject(Coin coin) => Destroy(coin.gameObject);

    private void ReleaseObject(Coin coin) => pool.Release(coin);

    private void Start() => StartCoroutine(SpawnCoins());

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Coin coin = pool.Get();
            coin.transform.position = GenerateRandomPosition();
            coin.Init(ReleaseObject);
        }
    }

    private Vector2 GenerateRandomPosition() => new Vector2(Random.Range(minX, maxX), transform.position.y);
}