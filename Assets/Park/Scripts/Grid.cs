using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Place_Point place;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unit")
        {
            place = collision.GetComponent<Place_Point>();
            Transform parentObject = transform;

            // 자식 오브젝트가 있는지 확인
            if (parentObject.childCount > 0)
            {
                place.canPlace = false;
            }
            else
            {
                place.canPlace = true;
            }
        }
    }
}
