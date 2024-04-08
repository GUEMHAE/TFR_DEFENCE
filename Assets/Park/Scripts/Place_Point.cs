using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Point : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]public bool canPlace = false;
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
        else if (collision.tag == "Grid" && !canPlace)
        {
            if (Input.GetMouseButtonUp(1))
            {
                grid = null;
                transform.localPosition = Vector3.zero;
                Debug.Log("À¯´Ö³¢¸® °ãÄ§");
            }    
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
            Debug.Log("ÄÝ¶óÀÌ´õ¿¡¼­ ³ª°¨");
            canPlace = true;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (canPlace && grid != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.SetParent(grid.transform);
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.4f, 0.4f);
        }
        if (grid == null)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.4f, 0.4f);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        boxCol.size = new Vector2(0.05f, 0.05f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }
}
