using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public PlayerInPutController inputControl;

    private Rigidbody2D rb;//rb���ڻ�ȡRigidbody����ı���


    public SpriteRenderer sr;//sr���ڻ�ȡSpriteRenderer����ı���

    [Header("��������")]
    public Vector2 inputDirection;//����

    public float walkSpeed,runSpeek;//�ƶ��ٶ�

    public float jumpForce;//��Ծ����

    private PhysicsCheck physicsCheck;//���ڻ�ȡ�ű�PhysicsCheck�еı�����isGround��

    public int jumpNum=0;//��¼��Ծ����

    public float leftPressTime, rightPressTime;

    public float maxAwaitTime;

    public bool isWalk,canRun;

    


    private void Awake()
    {
        inputControl = new PlayerInPutController();

        rb = GetComponent<Rigidbody2D>();//��ȡ
        sr = GetComponent<SpriteRenderer>();
        physicsCheck = GetComponent<PhysicsCheck>();

        inputControl.gamePlayer.Jump.started += Jump;//�¼�ע�᣺ += ��started������������һ�̣���Jump��������started�¼���ִ��
        
    }



    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.gamePlayer.Move.ReadValue<Vector2>();//��ȡ��������ķ���
    }

    private void FixedUpdate()
    {
        checkRunWalk();
        Move();//ʹ���ƶ�����
        if (physicsCheck.isGround == true)
            jumpNum = 0;
    }

    public void Move()//�ƶ�����
    {
        if(isWalk == true&&inputDirection.x!=0)
            rb.velocity = new Vector2(inputDirection.x * walkSpeed * Time.deltaTime, rb.velocity.y);
        if(isWalk == true &&canRun == true&&inputDirection.x!=0)
            rb.velocity = new Vector2(inputDirection.x * runSpeek * Time.deltaTime, rb.velocity.y);
        if(inputDirection.x == 0)
            rb.velocity = new Vector2(0, rb.velocity.y);

        //�޸�rigidboy����е��ٶ�ֵ��ʵ���ƶ�
        //rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
        //isWalk = true;



        #region 1���﷭ת,���޸�transform.localScaleʵ��
        //int faceDir= (int)transform.localScale.x;//�洢����
        //if(inputDirection.x>0)
        //    faceDir = 5;//ͼƬ�ز�̫С
        //if(inputDirection.x<0)
        //    faceDir = -5;
        //transform.localScale = new Vector3(faceDir, 5, 5);
        #endregion

        #region ���﷭ת���޸�Sprite Renderer.FlipXʵ��
        //2���﷭ת�����޸�Sprite Renderer.FlipXʵ��
        int faceDir = (int)inputDirection.x;
        if (faceDir > 0)
            sr.flipX = false;
        if (faceDir < 0)
            sr.flipX = true;
        #endregion
    }

    private void checkRunWalk()
    {
        if (inputDirection.x > 0 && !isWalk)
        {
            isWalk = true;
            if (Time.time - rightPressTime <= maxAwaitTime)
                canRun = true;
            rightPressTime = Time.time;
        }

        if (inputDirection.x < 0 && !isWalk)
        {
            isWalk = true;
            if (Time.time - leftPressTime <= maxAwaitTime)
                canRun = true;
            leftPressTime = Time.time;
        }
        if(inputDirection.x == 0)
        {
            isWalk = false;
            canRun = false;
        }
        
    }


    private void Jump(InputAction.CallbackContext context)//��Ծ����
    {
        //Debug.Log("JUMP!");
        if (physicsCheck.isGround == true || jumpNum <1)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpNum++;
        }
    }
}
