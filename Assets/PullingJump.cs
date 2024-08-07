using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    [SerializeField] float groundAngleLimit = 30;
    [SerializeField] float jumpSpeed = 10f;
    Rigidbody rb;
    Vector3 clickPosition;
    /// <summary>ジャンプ辛倦フラグ</summary>
    bool canJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;    // マウスのいる恙��
        }   // ドラッグ�_兵を�奮�
        else if (canJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // ベクトルの�Lさを誼る            
            float size = dragVector.magnitude;
            rb.velocity = dragVector.normalized * jumpSpeed;
        }   // �xしたらジャンプ
    }


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // 隈��をとってくる
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        Debug.Log(collision.gameObject.name + " にぶつかった");
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
        Debug.Log(collision.gameObject.name + " と�xれた");
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // 隈��をとってくる
        float angle = Vector3.Angle(normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        // Debug.Log("くっついている");
    }
}