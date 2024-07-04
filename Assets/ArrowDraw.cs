using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDraw : MonoBehaviour
{
    /// <summary>�ɥ�å��_ʼ����</summary>
    Vector3 clickPosition;
    /// <summary>ʸӡ�λ���</summary>
    [SerializeField] UnityEngine.UI.Image arrowImage;

    void Start()
    {
        // ʸӡ�λ��������
        arrowImage.gameObject.SetActive(false);
    }
        
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ʸӡ�λ�������
            arrowImage.gameObject.SetActive(true);
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            clickPosition = Input.mousePosition;    // �ޥ����Τ�������
            // ʸӡ�λ����ɥ�å��_ʼλ�ä��ƄӤ���
            arrowImage.rectTransform.position = clickPosition;
        }   // �ɥ�å��_ʼ��ʳ�
        else if (Input.GetMouseButton(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // �٥��ȥ���L����ä�            
            float size = dragVector.magnitude;
            // ʸӡ��٥��ȥ�η�����򤱤�
            arrowImage.rectTransform.right = dragVector;
            // �ɥ�å��򤿤����󤷤���ʸӡ��󤭤�����
            arrowImage.rectTransform.sizeDelta = Vector2.one * size;
        }   // �ɥ�å����Ƥ����g�I����
        else if (Input.GetMouseButtonUp(0))
        {
            // ʸӡ�λ��������
            arrowImage.gameObject.SetActive(false);
        }
    }
}