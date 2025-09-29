using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] Rigidbody2D bulletrb;
    [SerializeField] CapsuleCollider2D bulletCollider;
    [SerializeField] float bulletSpeed;
    float xSpeed;
    [SerializeField] PlayerMovement player;
    void Start()
    {
        bulletrb = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<CapsuleCollider2D>();
        player = GameObject.Find("Şevket (Player)").GetComponent<PlayerMovement>();
        
    }

    
    void Update()
    {
        BumerangShoot();
    }

    void BumerangShoot()
    {
        xSpeed = player.transform.localScale.x * bulletSpeed;
        bulletrb.linearVelocity = new Vector2(xSpeed, bulletrb.linearVelocity.y);
        Destroy(gameObject, 0.6f);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(collision.gameObject);
        }
    }
}
