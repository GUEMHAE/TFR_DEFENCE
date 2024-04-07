using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Point : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]private bool canPlace = false;
    public GameObject grid;
    BoxCollider2D boxCol;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        canPlace = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grid" && canPlace)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            grid = collision.gameObject;
        }
        else
        {
            grid = null;
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
        if (canPlace && grid != null)
        {
            transform.SetParent(grid.transform);
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.65f, 0.65f);
        }
        if (grid == null)
        {
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.65f, 0.65f);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        boxCol.size = new Vector2(0.08f, 0.08f);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }
}
