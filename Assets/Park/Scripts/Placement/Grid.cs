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
        }
    }
}
