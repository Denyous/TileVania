using UnityEngine;

public class FinishAllLevel : MonoBehaviour
{
   
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collect"))
        {
            FindObjectOfType<GameSession>().FinishGameScreen();
        }
    }
}
