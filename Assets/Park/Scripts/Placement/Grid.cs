using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Place_Point place;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Unit"))
    //    {
    //        place = collision.GetComponent<Place_Point>();

    //        if (transform.childCount > 0) // �ش� �׸��忡 �̹� �ٸ� ������ �ִ� ���
    //        {
    //            place.canPlace = false;
    //        }
    //        else // �ش� �׸��忡 �ٸ� ������ ���� ���
    //        {
    //            place.canPlace = true;
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Unit"))
    //    {
    //        place = collision.GetComponent<Place_Point>();
    //        place.canPlace = true; // ������ �׸��忡�� ��� �� �ٽ� �̵� �����ϵ��� ����
    //    }
    //}
}
