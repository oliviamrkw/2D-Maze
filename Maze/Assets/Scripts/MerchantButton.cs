using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchantButton : MonoBehaviour
{
    public GameManager gameManager;

    public void LifeButton()
    {
        gameManager.PurchaseLife();
    }
}
