using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("�ٶ����")]
    public float playmovespeed;
    public float playerJumpSpeed;
    [Header("��Ծ����")]
    public float playerJumpCount;
    [Header("�ж����")]
    public bool isGround;
    public bool isJump;
    public bool pressedJump;
    [Header("�������")]
    public Transform foot;
    public LayerMask Ground;
    public Rigidbody2D playerRB;
    public Collider2D playColl;
    public Animator PlayerAnim;

    void Start()
    {
        playColl = GetComponent<Collider2D>();              //�������ܲ�����ײ �����
        playerRB = GetComponent<Rigidbody2D>();             
        PlayerAnim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        UpdateCheck();
    }
    private void FixedUpdate()
    {
        PlayMove();                                      //һֱ�����ܹ��ƶ�
        PlayerJump();                                    //��Ծ
        FixupdateCheck();


    }
    void PlayMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal");      //�ƶ�
        float faceNum = Input.GetAxisRaw("Horizontal");    //�ı��ƶ������沿����
        playerRB.velocity = new Vector2(playmovespeed * horizontalNum, playerRB.velocity.y);
        PlayerAnim.SetFloat("run", Mathf.Abs(playmovespeed * horizontalNum)); //ȷ��ֹͣ��ʱ�򶯻��ı�
        if(faceNum!=0)   //�ı��沿����
        {
            transform.localScale = new Vector3(-faceNum, transform.localScale.y, transform.localScale.z);
        }

    }
    void PlayerJump()
    {
        if(isGround)
        {
            playerJumpCount = 1;
            isJump = false;
        }
        if(pressedJump && isGround)        
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed);
            PlayerAnim.SetBool("jump", true);
            playerJumpCount--;
        }
        else if ((pressedJump && playerJumpCount>0&& !isGround))   //�ڿ���
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed);  //���Զ�����
            playerJumpCount--;
        }
        if (isGround)
        {
            PlayerAnim.SetBool("jump", false);
        }
    }
    void FixupdateCheck()
    {
        isGround = Physics2D.OverlapCircle(foot.position, 0.1f, Ground);
    }
    void UpdateCheck()
    {
        if(Input.GetButtonDown("Jump"))
        {
            pressedJump = true;
        }
       
    }
}
