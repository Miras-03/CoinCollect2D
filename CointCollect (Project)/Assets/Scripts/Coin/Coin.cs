using System;
using UnityEngine;

public sealed class Coin : MonoBehaviour
{
    public static event Action OnTakenCoin;
    private Action<Coin> OnRelease;

    public void Init(Action<Coin> OnRelease) => this.OnRelease = OnRelease;

    private void OnTriggerEnter(Collider other)
    {
        OnRelease(this);
        if (other.CompareTag("Player"))
            OnTakenCoin.Invoke();
    }
}