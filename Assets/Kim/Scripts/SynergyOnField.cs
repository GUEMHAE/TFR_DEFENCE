using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SynergyOnField : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> allUnits; //유닛 리스트
    [SerializeField]
    List<GameObject> allGrid; //그리드 리스트

    static public SynergyOnField instance;

    public void GetOnlyGridUnits()
    {
        allUnits.Clear();

        foreach (GameObject Grid in allGrid)
        {
            foreach (Transform child in Grid.transform)
            {
                if (child != Grid.transform)
                {
                    allUnits.Add(child.gameObject); //그리드 상의 자식 오브젝트를 받아서 allUnit(유닛 리스트)에 추가
                }
            }
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        GetOnlyGridUnits();
    }
}
