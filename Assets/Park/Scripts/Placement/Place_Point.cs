using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Point : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] public bool canPlace = false;
    public GameObject grid;
    public GameObject Unit;
    BoxCollider2D boxCol;
    public AudioSource setUnit;

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        boxCol = GetComponent<BoxCollider2D>();
        boxCol.size = new Vector2(1f, 1f);
        canPlace = true;

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
        if (collision.tag == "Grid" && canPlace)
        {
            grid = collision.gameObject;
        }

        else if (collision.tag == "Wait" && canPlace)
        {
            grid = collision.gameObject;
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
            setUnit.Play();
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.SetParent(grid.transform);
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1);
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(1f, 1f);
        }
        else if (grid == null)
        {
            setUnit.Play();
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1);
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(1f, 1f);
        }
        else
        {
            setUnit.Play();
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            grid = null;
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1);
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
