using UnityEngine;

public class CoinCollect : MonoBehaviour
{
     
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collect"))
        {
            FindObjectOfType<GameSession>().ScoreUpdate(); // Score update oluyor
            
            Destroy(gameObject);
        }
    }
}
