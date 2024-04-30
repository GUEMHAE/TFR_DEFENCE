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
    private Unit unit;

    Round round;
    GameObject RoundManager;
    private void Start()
    {
        RoundManager = GameObject.FindWithTag("Round");
        boxCol = GetComponent<BoxCollider2D>();
        round = RoundManager.GetComponent<Round>();
        canPlace = true;
        unit = GetComponent<Unit>();
        unit.enabled = false;
        Debug.Log(unit.enabled);
    }
    

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (round.isRound == true && collision.tag != "Wait")
        {
            canPlace = false;
        }

        if (collision.tag == "Grid" && canPlace || collision.tag == "Wait" && canPlace)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            grid = collision.gameObject;
        }
        else if (collision.tag == "Grid" && !canPlace || collision.tag == "Wait" && !canPlace)
        {
            if (Input.GetMouseButtonUp(1))
            {
                grid = null;
                transform.localPosition = Vector3.zero;
                Debug.Log("À¯´Ö³¢¸® °ãÄ§");
            }
        }
        else if (collision.tag == "Wait")
        {
            canPlace = true;
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grid" || collision.tag == "Wait")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            canPlace = true;
            grid = null;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (canPlace && grid != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.SetParent(grid.transform);
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.5f, 0.5f);
        }
        else if (grid == null)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.5f, 0.5f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            grid = null;
            transform.localPosition = Vector3.zero;
            boxCol.size = new Vector2(0.5f, 0.5f);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        boxCol.size = new Vector2(0.065f, 0.065f);
        unit.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }
}
