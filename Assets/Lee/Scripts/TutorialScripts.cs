using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialScripts : MonoBehaviour, IEndDragHandler
{
    public GameObject goGrid;
    public GameObject enemy_0;

    public string GridName;
    public GameObject IMG_Grid;
    private bool isGrid = false;

    public string waitsName;
    private bool iswaits = false;
    public GameObject turorial;

    private void Awake()
    {
        turorial = GameObject.Find("111");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isGrid && IMG_Grid.activeSelf == false)
        {
            IMG_Grid.SetActive(true);
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

        if (collision.tag == "Grid" )
        {
            IMG_Grid.SetActive(false);
            goGrid.SetActive(false);
            gameObject.transform.SetParent(turorial.transform);
            Round.instance.isRound = true;
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