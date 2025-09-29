using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private AudioManager audioManager;
   
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collect"))
        {
            FindObjectOfType<GameSession>().ScoreUpdate(); // Score update oluyor

            audioManager.PlaySFX(audioManager.coinCollect);

            Destroy(gameObject);


        }
    }
}
