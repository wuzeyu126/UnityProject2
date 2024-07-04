using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDraw : MonoBehaviour
{
    /// <summary>¥É¥é¥Ã¥°é_Ê¼×ù˜Ë</summary>
    Vector3 clickPosition;
    /// <summary>Ê¸Ó¡¤Î»­Ïñ</summary>
    [SerializeField] UnityEngine.UI.Image arrowImage;

    void Start()
    {
        // Ê¸Ó¡¤Î»­Ïñ¤òÏû¤¹
        arrowImage.gameObject.SetActive(false);
    }
        
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Ê¸Ó¡¤Î»­Ïñ¤ò³ö¤¹
            arrowImage.gameObject.SetActive(true);
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            clickPosition = Input.mousePosition;    // ¥Þ¥¦¥¹¤Î¤¤¤ë×ù˜Ë
            // Ê¸Ó¡¤Î»­Ïñ¤ò¥É¥é¥Ã¥°é_Ê¼Î»ÖÃ¤ËÒÆ„Ó¤¹¤ë
            arrowImage.rectTransform.position = clickPosition;
        }   // ¥É¥é¥Ã¥°é_Ê¼¤ò—Ê³ö
        else if (Input.GetMouseButton(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // ¥Ù¥¯¥È¥ë¤ÎéL¤µ¤òµÃ¤ë            
            float size = dragVector.magnitude;
            // Ê¸Ó¡¤ò¥Ù¥¯¥È¥ë¤Î·½Ïò¤ËÏò¤±¤ë
            arrowImage.rectTransform.right = dragVector;
            // ¥É¥é¥Ã¥°¤ò¤¿¤¯¤µ¤ó¤·¤¿¤éÊ¸Ó¡¤ò´ó¤­¤¯¤¹¤ë
            arrowImage.rectTransform.sizeDelta = Vector2.one * size;
        }   // ¥É¥é¥Ã¥°¤·¤Æ¤¤¤ëég„IÀí¤¹¤ë
        else if (Input.GetMouseButtonUp(0))
        {
            // Ê¸Ó¡¤Î»­Ïñ¤òÏû¤¹
            arrowImage.gameObject.SetActive(false);
        }
    }
}