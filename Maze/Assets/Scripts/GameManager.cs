using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtTopDown_Basic;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;

    private PlayerLife playerLife;

    public AudioSource purchase;
    public AudioSource decline;

    void Start()
    {
        playerLife = player.GetComponent<PlayerLife>();
    }

    void Update()
    {
        int playerHealth = playerLife.getLives();
        healthText.text = $"Health: {playerHealth}";

        int playerCoins = playerLife.getCoins();
        coinsText.text = $"Coins: {playerCoins}";

        if (playerLife.getLives() <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void PurchaseLife()
    {
        if (playerLife.getCoins() >= 5)
        {
            playerLife.removeCoins(5);
            playerLife.gainLife();
            purchase.Play();
        }
        else
        {
            decline.Play();
        }
    }

    public void KillEnemy(int coins)
    {
        playerLife.addCoins(coins);
    }
}
