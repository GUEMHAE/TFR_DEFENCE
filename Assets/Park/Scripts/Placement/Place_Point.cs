using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Point : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] public bool canPlace = false;
    public GameObject grid;
    public GameObject Unit;
    private BoxCollider2D boxCol;
    private SpriteRenderer spriteRenderer;
    private static readonly Vector3 DefaultScale = new Vector3(0.8f, 0.8f, 1);
    private static readonly Vector3 DragScale = new Vector3(1, 1, 1);
    private static readonly Vector2 DefaultBoxSize = new Vector2(1f, 1f);
    private static readonly Vector2 DragBoxSize = new Vector2(0.065f, 0.065f);

    private void Start()
    {
        transform.localScale = DefaultScale;
        boxCol = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCol.size = DefaultBoxSize;
    }

    private void Update()
    {
        var raycaster = Camera.main.GetComponent<Physics2DRaycaster>();
        if (raycaster != null)
        {
            raycaster.enabled = !Round.instance.isRound;
        }

        if (UnitLimitManager.instance.MaxunitCount <= UnitLimitManager.instance.curUnitCount)
        {
            canPlace = false;
        }
        else
        {
            canPlace = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid") && canPlace)
        {
            grid = collision.gameObject;
        }
        else if(collision.CompareTag("Wait"))
        {
            grid = collision.gameObject;
        }
        else
        {
            ResetTransform();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid"))
        {
            grid = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canPlace && grid != null)
        {
            CheckAndSwapParent(); // 변경된 부분: CheckAndSwapParent 함수 호출
            PlaceUnit();
        }
        else
        {
            ResetTransform();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localScale = DragScale;
        boxCol.size = DragBoxSize;
        spriteRenderer.sortingOrder = 4;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    private void PlaceUnit()
    {
        spriteRenderer.sortingOrder = 1;
        transform.SetParent(grid.transform);
        ResetTransform();
    }

    private void ResetTransform()
    {
        transform.localScale = DefaultScale;
        transform.localPosition = Vector3.zero;
        boxCol.size = DefaultBoxSize;
        spriteRenderer.sortingOrder = 1;
    }

    private void CheckAndSwapParent()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, DefaultBoxSize, 0);
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Unit") && col.transform != transform)
            {
                // 다른 유닛이 이미 해당 위치에 있는 경우
                Unit = col.gameObject;
                Unit.transform.SetParent(transform.parent); // 다른 유닛의 부모 오브젝트를 현재 위치의 그리드로 변경
                Unit.GetComponent<Place_Point>().ResetTransform(); // 다른 유닛의 위치 재설정
                transform.SetParent(grid.transform); // 현재 유닛의 부모 오브젝트를 그리드로 변경
                return;
            }
        }
    }
}
