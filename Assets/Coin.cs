using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int CoinValue;

    
    public void Collect(GameObject Hero)
    {
        bool isHero = Hero.TryGetComponent(out Player player);
        if (!isHero)
        {
            return;
        }
        player.AddCoin(CoinValue);
    }
}
