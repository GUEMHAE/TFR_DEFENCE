using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Point : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]public bool canPlace = false;
    public GameObject grid;
    public GameObject Unit;
    BoxCollider2D boxCol;

    Renderer render;

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        boxCol = GetComponent<BoxCollider2D>();
        boxCol.size = new Vector2(1f, 1f);
        canPlace = true;
        render = GetComponent<Renderer>();
        render.material.DisableKeyword("OUTBASE_ON");

    }

    private void Update()
    {
        if (Round.instance.isRound == true)
        {
            Camera.main.GetComponent<Physics2DRaycaster>().enabled = false;
        }
        else
        {
            Camera.main.GetComponent<Physics2DRaycaster>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grid" && canPlace || collision.tag == "Wait" && canPlace)
        {
            grid = collision.gameObject;
            render = GetComponent<Renderer>();
            render.material.EnableKeyword("OUTBASE_ON");
        }
        else if (collision.tag == "Grid" && !canPlace || collision.tag == "Wait" && !canPlace)
        {
            if (Input.GetMouseButtonUp(1))
            {
                grid = null;
                transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grid")
        {
            render.material.DisableKeyword("OUTBASE_ON");
            canPlace = true;
            grid = null;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //if (UnitLimitManager.instance.curUnitCount >= UnitLimitManager.instance.MaxunitCount)
        //{
        //    Debug.Log("배치불가");
        //    gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //    grid = null;
        //    gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        //    transform.localPosition = Vector3.zero;
        //    boxCol.size = new Vector2(1f, 1f);
        //}
        if (canPlace && grid != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.SetParent(grid.transform);
            gameObject.transform.localScale = new Vector3(0.8f,0.8f, 1) ;
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(1f, 1f);
        }
        else if (grid == null)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            gameObject.transform.localScale = new Vector3(0.8f,0.8f, 1) ;
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(1f, 1f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            grid = null;
            gameObject.transform.localScale = new Vector3(0.8f,0.8f, 1) ;
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(1f, 1f);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        boxCol.size = new Vector2(0.065f, 0.065f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }
}
