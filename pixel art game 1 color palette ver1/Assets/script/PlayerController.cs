using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputDirection;
    private float facingDirection;
    private bool inputJump;
    private bool inputDash;
    private bool isJumping;
    
    [Header("basic movement")]
    public float speedPlayer =5f;
    public float jumpForce = 5f;
    public Transform groundPos;
    public float radiusGroundCheck =0.5f;
    public LayerMask whatIsGround;

    // [Header("Special Skill")]
    // public float DashForce = 10f;
    // public float timeBtwDashing = 1f;
    // public float DashingDuration = 0.3f;
    // private float startDashing;
    // private bool isDashing;

    // Start is called before the first frame update
    
    [Header("Player Life")]
    public int playerHealth = 5;
    public GameObject deadPlayerParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        facingDirection = 1;
        // startDashing = timeBtwDashing;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        setVelocityX(inputDirection, speedPlayer);
        setVelocityY(jumpForce);
        Flip();
        // IfPlayerDashing();
    }

    public void FixedUpdate() {
    }

    public void CheckForInput(){
        inputDirection = Input.GetAxisRaw("Horizontal");
        inputJump = Input.GetKeyDown(KeyCode.Space);
        // inputDash = Input.GetKeyDown(KeyCode.Z);
        
        // if (inputDash){
        //     isDashing = true;
        // } else isDashing = false;

        if (inputJump){
            isJumping = true;
        }
        else isJumping = false;
    }

    public void Flip(){
        if (inputDirection < 0 && facingDirection == 1){
            transform.Rotate(0,180,0);
            facingDirection = -1;
        }
        else if (inputDirection > 0 && facingDirection == -1){
            transform.Rotate(0,180,0);
            facingDirection = 1;
        }
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundPos.position, radiusGroundCheck, whatIsGround);
    }

    public void setVelocityX(float direction, float speed)
    {
        rb.velocity = new Vector2 (direction*speed, rb.velocity.y);
    }

    public void setVelocityY(float jumpForce)
    {
        if (isJumping & isGrounded()){
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        }
    }

    public void Damage(int damage){
        playerHealth -= damage;
        if (playerHealth < 0)
        {
            Instantiate(deadPlayerParticle, transform.position, Quaternion.identity);
            Destroy(gameObject); 
        }
    }

    // public void IfPlayerDashing(){
    //     startDashing -= Time.deltaTime;
    //     if (isDashing && startDashing < 0){
    //         setVelocityX(facingDirection, DashForce);
    //         startDashing = timeBtwDashing;
    //     }
    // }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundPos.position, radiusGroundCheck);
    }
}
