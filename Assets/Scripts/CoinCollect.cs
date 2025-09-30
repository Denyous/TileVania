using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField] public  int point;
   
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collect"))
        {
            FindObjectOfType<GameSession>().ScoreUpdate(point); // Score update oluyor

            audioManager.PlaySFX(audioManager.coinCollect);

            Destroy(gameObject);


        }
    }
}
