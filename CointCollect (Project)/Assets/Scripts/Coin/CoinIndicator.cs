using TMPro;
using UnityEngine;

public sealed class CoinIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private int coinCount = 0;

    private void Start() => Coin.OnTakenCoin += UpdateCoinCount;

    private void UpdateCoinCount() => coinText.text = $"Coint count: {++coinCount}";
}