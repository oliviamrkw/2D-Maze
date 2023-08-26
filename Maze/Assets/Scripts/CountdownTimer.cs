using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timer; 
    public float timeLeft = 200f;

    public AudioSource getItem;

    private void Start()
    {
        StartCountdown();
    }

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Time"))
        {
            timeLeft += 10f;
            Destroy(other.gameObject);
            getItem.Play();
        }
    }

    private IEnumerator Countdown()
    {
        // Update the countdown text while there is time remaining
        while (timeLeft > 0)
        {
            timer.text = "Time left: " + timeLeft.ToString();
            yield return new WaitForSeconds(1f); // Wait for one second before updating the countdown
            timeLeft--;
        }

        timer.text = "Out of time!";
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }

}
