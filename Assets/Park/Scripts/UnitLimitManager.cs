using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLimitManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> allUnits;
    [SerializeField]
    List<GameObject> allGrid;

    public static UnitLimitManager instance; //ΩÃ±€≈Ê ∆–≈œ

    public void GetOnlyGridUnits()
    {
        allUnits.Clear();

        foreach (GameObject Grid in allGrid)
        {
            foreach (Transform child in Grid.transform)
            {
                if (child != Grid.transform)
                {
                    allUnits.Add(child.gameObject);
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
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }
}
