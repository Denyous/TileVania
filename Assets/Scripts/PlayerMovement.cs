using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = System.Diagnostics.Debug;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D bodyCollider;
    [SerializeField] CapsuleCollider2D feetCollider;
    [SerializeField] float linearSpeedX = 1.0f;
    [SerializeField] float jumpspeedY = 1.0f;
    [SerializeField] float climbSpeedX = 3f;
    [SerializeField] DeathState deathstate;
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] Vector2 deathKick = new Vector2(6f, 6f);
    [SerializeField] PlayerInput characterController;
    [SerializeField] GameObject bumerang;
    [SerializeField] Transform bumerangLocation;
    [SerializeField] GameSession gameSession;

    private bool hasHorizontalSpeed;
    private Vector2 moveInput;
    private bool isTouchingGround = true;
    private float baseGravityScale;
    private float gravityScale;
    private bool isAlive = true;
    [SerializeField] int bulletRight = 5;
    private int bulletCount = 0;





    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<BoxCollider2D>();
        feetCollider = GetComponent<CapsuleCollider2D>();
        baseGravityScale = playerRb.gravityScale;
        characterController = GetComponent<PlayerInput>();
        playerSprite = GetComponent<SpriteRenderer>();
        deathstate = GameObject.Find("GameManager").GetComponent<DeathState>();

        
        


    }

    void Update()
    {
        playerRb.gravityScale = baseGravityScale;
        Run();
        FlipSprite();
        Climb();
        HazardControl();

    }



    #region Player Move
    void Run()
    {

        float speed = linearSpeedX * moveInput.x;     // hız çarpanı ile hareket inputu çarpılıyor.
        Vector2 playerVelocity = new Vector2(speed, playerRb.linearVelocityY);     // y ekseni için velocity değeri veriliyor.
        playerRb.linearVelocity = playerVelocity;    // oyun fiziğine göre hız değeri aktarılıyor.

        if (Mathf.Abs(playerVelocity.x) > 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

    }



    void FlipSprite()
    {
        hasHorizontalSpeed = Mathf.Abs(playerRb.linearVelocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.linearVelocityX), 1f);

        }

    }


    void OnJump(InputValue value)
    {
        isTouchingGround = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (value.isPressed && isTouchingGround)
        {
            playerRb.linearVelocity += new Vector2(0f, jumpspeedY);

        }
    }

    void OnMove(InputValue value)
    {
        
        moveInput = value.Get<Vector2>();

    }

    void OnAttack(InputValue value)
    {
        if (bulletCount<= bulletRight)
        {
            Instantiate(bumerang, bumerangLocation.position, transform.rotation);
            bulletCount++;
        }
        else
        {
            Debug.Write("you cannot shoot anymore!");
        }
        

    }




    void Climb()
    {

        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            playerRb.gravityScale = 0;
            float climbSpeed = moveInput.y * climbSpeedX;
            Vector2 climbVelocity = new Vector2(playerRb.linearVelocity.x, climbSpeed);     // y ekseni için velocity değeri veriliyor.
            playerRb.linearVelocity = climbVelocity;    // oyun fiziğine göre hız değeri aktarılıyor.



            if (Mathf.Abs(climbSpeed) > Mathf.Epsilon)
            {

                animator.SetBool("IsClimbing", true);

            }

            if (Mathf.Abs(climbSpeed) < Mathf.Epsilon)
            {
                animator.SetBool("IsClimbing", false);
            }



        }


    }


    void HazardControl()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            Die();
        }
    }



    #endregion
    #region Collisions-Handler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isAlive = false;

            if (!isAlive)
            {
                Die();

            }
        }

    }

  

    public void Die()
    {
        characterController.enabled = false;
        animator.SetTrigger("IsDead");
        playerSprite.color = Color.red;
        playerRb.linearVelocity = deathKick;
        FindObjectOfType<GameSession>().PlayerDeathState();
   

    }


}
#endregion