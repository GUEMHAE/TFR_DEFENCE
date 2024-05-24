using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Point : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject grid;
    public GameObject Unit;
    public bool canAttack;
    private string begintag;
    private BoxCollider2D boxCol;
    private SpriteRenderer spriteRenderer;
    private static readonly Vector3 DefaultScale = new Vector3(0.8f, 0.8f, 1);
    private static readonly Vector3 DragScale = new Vector3(1, 1, 1);
    private static readonly Vector2 DefaultBoxSize = new Vector2(1f, 1f);
    private static readonly Vector2 DragBoxSize = new Vector2(0.065f, 0.065f);

    bool canSwap;
    int defaultLayer;
    private void Start()
    {
        transform.localScale = DefaultScale;
        boxCol = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCol.size = DefaultBoxSize;
        defaultLayer = 1 << LayerMask.NameToLayer("Default");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid"))
        {
            grid = collision.gameObject;
        }
        if (collision.CompareTag("Wait"))
        {
            grid = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid"))
        {
            grid = null;
        }
        if (collision.CompareTag("Wait"))
        {
            grid = null;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        begintag = transform.parent.tag;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!Round.instance.isRound)
        {
            CheckAndSwapParent();
        }
        if (grid != null && begintag == "Grid")
        {
            PlaceUnit();
        }
        else if(grid != null && UnitLimitManager.instance.curUnitCount < UnitLimitManager.instance.MaxunitCount && begintag == "Wait" && !Round.instance.isRound)
        {
            PlaceUnit();
        }
        else
        {
            ResetTransform();
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Round.instance.isRound && !transform.parent.CompareTag("Wait"))
            return;
        canAttack = false;

        transform.localScale = DragScale;
        boxCol.size = DragBoxSize;
        spriteRenderer.sortingOrder = 4;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    private void PlaceUnit()
    {
        if (transform.parent.CompareTag("Grid"))
            canAttack = true;
        else
            canAttack = false;
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
                // �ٸ� ������ �̹� �ش� ��ġ�� �ִ� ���
                Unit = col.gameObject;

                // ���� ���ְ� �ٸ� ������ �θ� ��ȯ
                Transform tempParent = Unit.transform.parent;
                Unit.transform.SetParent(transform.parent);
                transform.SetParent(tempParent);

                // ��ġ �缳��
                Unit.GetComponent<Place_Point>().ResetTransform();
                ResetTransform();

                return;
            }
        }
        if (transform.parent.CompareTag("Grid"))
            canAttack = true;
        else
            canAttack = false;
    }

    // ���� ���� üũ
    private bool IsUnitLimitReached()
    {
        return UnitLimitManager.instance.MaxunitCount <= UnitLimitManager.instance.curUnitCount;
    }

    
}
