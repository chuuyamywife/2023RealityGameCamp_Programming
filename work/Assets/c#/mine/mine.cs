using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour//���׽ű�
{
    //���ɲ���
    public float ricochetOff = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("1");
        //����ը�ɺͼ��
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, ricochetOff);
            //����Ƿ�͵��׽Ӵ�������boolֵ
            player.Contactmine = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
