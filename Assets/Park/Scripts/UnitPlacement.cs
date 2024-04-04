using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacement : MonoBehaviour
{
    public GameObject unit;
    public GameObject unitClone;

    private Camera mainCamera;
    public bool isPlace = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (isPlace == false)
        {
            OnPlace();
        }
        
    }

    void OnPlace()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPlace = true;
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            unitClone =  Instantiate(unit, mousePos, Quaternion.identity);
        } 
    }
}
