using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;
public class player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public bool canJump;
    public Animator animator;
    //������Ծ����
    public float jumpParameter = 5.0f;
    //�����ƶ��ٶ�
    public float speed = 5.0f;
    //�Ƿ�͵��׽Ӵ���boolֵ
    public static bool Contactmine;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ж��Ƿ��ƽ̨��ײ
        if (collision.gameObject.CompareTag("platform"))
        {
            canJump = true;
        }
        print(canJump);
    }

    // Update is called once per frame
    void Update()
    {
        //�����ƶ��Ĳ���
        float movex = Input.GetAxisRaw("Horizontal");
        //�����ƶ���ʵ��
        rb.velocity = new Vector2(movex * speed, rb.velocity.y);
        //�ƶ�����ʵ��
        if (canJump == true && movex != 0)
        {
            //���ҷ���ѡ����ת��
            if (movex > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (movex < 0)
            {
                spriteRenderer.flipX = true;
            }
            print("1");
            animator.SetBool("iswalk", true);
        }
        else
        {
            animator.SetBool("iswalk", false);
        }
        //����Ƿ������Ծ��׼
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            //��Ծ��ʵ��
            rb.velocity = new Vector2(rb.velocity.x, jumpParameter);
            canJump = false;

        }
        //��Ծ�Ķ���ʵ��
        if (canJump == false)
        {
            animator.SetBool("isjump", true);
        }
        else
        {
            animator.SetBool("isjump", false);
        }
   
        }
  
    void FixedUpdate()
    {
      
     
    }
    
}
