using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Place_Point place;
    public bool isGrid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unit")
        {
            place = collision.GetComponent<Place_Point>();
            Transform parentObject = transform;

            if (UnitLimitManager.instance.MaxunitCount <= UnitLimitManager.instance.curUnitCount)
            {
                place.canPlace = false;
            }

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
