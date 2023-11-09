using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [Header("������")]
    public Vector2 bottomOffset;//��ⷶΧ����ƫ��ֵ


    public float checkRaduis;//��ⷶΧ��С

    [Header("״̬")]
    public bool isGround;//�Ƿ��ڵ���

    public LayerMask groundLayer;
    private void Update()
    {
        Check();
    }

    public void Check()//��⴦�ڵ����״̬
    {
        
         isGround=Physics2D.OverlapCircle((Vector2)transform.position+bottomOffset,checkRaduis,groundLayer);
    }

    private void OnDrawGizmosSelected()//��ⷶΧ����
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset,checkRaduis);
    }
}
