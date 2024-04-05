using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePoint : MonoBehaviour
{
    public bool isPalce = false;
    public SpriteRenderer sprite;
    public GameObject unit;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Unit")
        {
            if (isPalce)
            {
                sprite.color = Color.red;
                unit.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                sprite.color = Color.green;
                onUnitPlace();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Unit")
        {
            sprite.color = Color.white;
        }
    }

    void onUnitPlace()
    {
        unit.transform.parent = transform;
        isPalce = true;
    }
}
