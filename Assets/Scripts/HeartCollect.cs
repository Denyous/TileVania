using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    
    void Start()
    {
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collect"))
        {
            FindObjectOfType<GameSession>().PlayerLiveUpdate();
            Destroy(gameObject);
        }
    }
}
