using System;
using UnityEngine;

public class TakeCoins : MonoBehaviour
{
    public static event Action OnTakenCoin;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        OnTakenCoin.Invoke();
    }
}
