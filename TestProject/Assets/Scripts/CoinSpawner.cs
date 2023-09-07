using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    private Vector3 randomPosition;

    private const int minX = -9;
    private const int maxX = 9;

    private void Start()
    {
        StartCoroutine(SpawnCoins());
        randomPosition = transform.position;
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(coin, randomPosition, Quaternion.identity);
            randomPosition = GenerateRandomPosition();
        }
    }

    private Vector2 GenerateRandomPosition()
    {
        int randomXPosition = Random.Range(minX, maxX);
        Vector2 randomPosition = new Vector2(randomXPosition, transform.position.y);

        return randomPosition;
    }
}
