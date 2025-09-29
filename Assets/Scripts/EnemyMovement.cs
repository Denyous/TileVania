using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 1f;

    Rigidbody2D enemyRb;
    BoxCollider2D wallDetector;
    CapsuleCollider2D enemyBody;



    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        wallDetector = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {

        EnemyMove();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            FlipEnemy();
            enemySpeed = -enemySpeed;
        }
       
    }


    void FlipEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRb.linearVelocity.x)), 1f);
    }
    void EnemyMove()
    {
        enemyRb.linearVelocity = new Vector2(enemySpeed, 0f);

    }
}
