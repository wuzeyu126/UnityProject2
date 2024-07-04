using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    [SerializeField] float groundAngleLimit = 30;
    [SerializeField] float jumpSpeed = 10f;
    Rigidbody rb;
    Vector3 clickPosition;
    /// <summary>�����׿ɷ�ե饰</summary>
    bool canJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;    // �ޥ����Τ�������
        }   // �ɥ�å��_ʼ��ʳ�
        else if (canJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // �٥��ȥ���L����ä�            
            float size = dragVector.magnitude;
            rb.velocity = dragVector.normalized * jumpSpeed;
        }   // �x�����饸����
    }


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // ������ȤäƤ���
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        Debug.Log(collision.gameObject.name + " �ˤ֤Ĥ��ä�");
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
        Debug.Log(collision.gameObject.name + " ���x�줿");
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // ������ȤäƤ���
        float angle = Vector3.Angle(normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        // Debug.Log("���äĤ��Ƥ���");
    }
}