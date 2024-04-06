using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacePoint : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool isPalce = false;
    public bool canPlace = false;
    public GameObject grid;
    Transform defaultPos;
    BoxCollider2D boxCol;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grid")
        {
            if (isPalce)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                canPlace = false;
            }
            else
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                grid = collision.gameObject;
                canPlace = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grid")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            grid = null;
        }
    }

   void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (canPlace && !isPalce && grid != null)
        {
            transform.SetParent(grid.transform);
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.7f, 0.7f);
        }
        if(grid == null)
        {
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.7f, 0.7f);
        }
    }
    

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        boxCol.size = new Vector2(0.1f, 0.1f);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }
}
