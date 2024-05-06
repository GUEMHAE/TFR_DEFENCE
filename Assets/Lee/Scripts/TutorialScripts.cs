using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks;
using System;

public class TutorialScripts : MonoBehaviour, IEndDragHandler
{
    public GameObject goGrid;
    public GameObject enemy_0;

    public string GridName;
    public GameObject IMG_Grid;
    private bool isGrid = false;

    public string waitsName;
    private bool iswaits = false;

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isGrid && !IMG_Grid.activeSelf)
        {
            IMG_Grid.SetActive(true);
        }
        else
        {
            IMG_Grid.SetActive(false);
            goGrid.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == GridName)
        {
            isGrid = true;
        }

        if (collision.gameObject.name == waitsName)
        {
            iswaits = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == GridName)
        {
            isGrid = false;
        }

        if (collision.gameObject.name == waitsName)
        {
            iswaits = false;
        }
    }
}