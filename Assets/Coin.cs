using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int CoinValue;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        //Debug.Log(player.name, player);
    }
    public void Collect()
    {
        player.AddCoin(CoinValue);
        Destroy(gameObject);
    }
}
