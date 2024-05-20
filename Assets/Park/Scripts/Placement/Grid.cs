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

    //        if (transform.childCount > 0) // 해당 그리드에 이미 다른 유닛이 있는 경우
    //        {
    //            place.canPlace = false;
    //        }
    //        else // 해당 그리드에 다른 유닛이 없는 경우
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
    //        place.canPlace = true; // 유닛이 그리드에서 벗어날 때 다시 이동 가능하도록 설정
    //    }
    //}
}
