using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;//ÒÆ¶¯
    public float speed = 6.0f;
    private float xVelocity;

    public float addForce = 10.0f;//ÌøÔ¾

    public bool isGrounded;//µØÃæÅÐ¶Ï
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    int n;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
        
    }

    private void FixedUpdate()
    {
       
        Scale();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Walk()
    {
        xVelocity = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

    }

    void Scale()//³¯Ïò
    {
        if (xVelocity < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (xVelocity > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    void Jump()
    {
        if (isGrounded == true)
        {
            n = 2;

        }
        if (Input.GetKeyDown(KeyCode.Space) && n > 1)
        {

            rb.velocity = addForce * Vector2.up;
            n--;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//ÏÝÚå
    {
        if (collision.collider.CompareTag("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
