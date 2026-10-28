using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TextMeshProUGUI coinText;

    private int coinCount = 0;
    private int totalCoins;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("coins").Length;
        coinText.text = "Coins: " + coinCount + "/" + totalCoins;
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "Coins: " + coinCount + "/" + totalCoins;
    }

    public bool AllCoinsCollected()
    {
        return coinCount >= totalCoins;
    }
}