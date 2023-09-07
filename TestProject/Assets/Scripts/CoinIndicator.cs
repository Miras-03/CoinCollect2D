using TMPro;
using UnityEngine;

public class CoinIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private int coinCount = 0;

    private void Start() => TakeCoins.OnTakenCoin += UpdateCoinCount;

    private void UpdateCoinCount() => coinText.text = $"Coint count: {++coinCount}";
}
