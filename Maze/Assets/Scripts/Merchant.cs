using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject canvas;

    void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
    
}
