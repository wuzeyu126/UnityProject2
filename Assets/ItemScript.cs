using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator _anim;
    private AudioSource audioSource;

    void Start()
    {
        _anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        
    }

    /// <summary>
    /// �@�å��˥�`�������������K��ä������
    /// ���֥������Ȥ��Ɨ�����
    /// </summary>
    void OnGetAnimationFinished()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        
  
        _anim.SetBool("IsGet", true);
        audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void DestorySelf()
    {
        Destroy(gameObject);
    }
}

