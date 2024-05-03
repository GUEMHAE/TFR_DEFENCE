using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Unit : MonoBehaviour
{
    RandomSprite_Unit Unit;
    public GameObject[] units;

    public GameObject grid;
    public GameObject Waits;
    public GameObject[] waitArray;
    public GameObject wait1;
    public GameObject wait2;
    public GameObject wait3;
    public GameObject wait4;
    public GameObject wait5;

    public bool canBuy;

    private void Start()
    {
        Unit = GetComponent<RandomSprite_Unit>();
        GameObject instance = Instantiate(units[PlayerPrefs.GetInt("Character")]);
        instance.transform.SetParent(grid.transform);
        instance.transform.localPosition = Vector3.zero;
        canBuy = true;
        Waits = wait1;
    }
    private void Update()
    {
        Checkwaitnull();
    }

    public void Checkwaitnull()
    {
        bool foundEmptyWait = false;

        foreach (var wait in waitArray)
        {
            if (wait.transform.childCount == 0)
            {
                foundEmptyWait = true;
                break;
            }
        }

        canBuy = foundEmptyWait;

        if (Waits.transform.childCount > 0)
        {
            canBuy = false;
        }

        if (wait1.transform.childCount == 0)
        {
            Waits = wait1;
        }
        else if (wait2.transform.childCount == 0)
        {
            Waits = wait2;
        }
        else if (wait3.transform.childCount == 0)
        {
            Waits = wait3;
        }
        else if (wait4.transform.childCount == 0)
        {
            Waits = wait4;
        }
        else if (wait5.transform.childCount == 0)
        {
            Waits = wait5;
        }
        else
        {
            Waits = wait1;
        }
    }

    public void ClickChampion(int index)
    {
        if (canBuy == true && Unit.imageSlots[index].sprite != null)
        {
            if (Unit.imageSlots[index].sprite.name == "1_Dark_dareubam")
            {
                GameObject instantiatedUnit = Instantiate(units[0], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "1_Fire_arokseu")
            {
                GameObject instantiatedUnit = Instantiate(units[1], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "1_Fire_bureu")
            {
                GameObject instantiatedUnit = Instantiate(units[2], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "1_Ground_babarian")
            {
                GameObject instantiatedUnit = Instantiate(units[3], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "1_Light_Water_seunel")
            {
                GameObject instantiatedUnit = Instantiate(units[4], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }


            if (Unit.imageSlots[index].sprite.name == "1_Light_tonireu")
            {
                GameObject instantiatedUnit = Instantiate(units[5], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }


            if (Unit.imageSlots[index].sprite.name == "1_Water_aeswi")
            {
                GameObject instantiatedUnit = Instantiate(units[6], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }


            if (Unit.imageSlots[index].sprite.name == "2_Dark_aseoseu")
            {
                GameObject instantiatedUnit = Instantiate(units[7], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "2_Ground_areute")
            {
                GameObject instantiatedUnit = Instantiate(units[8], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "2_Light Dark_ireusigeu")
            {
                GameObject instantiatedUnit = Instantiate(units[9], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "2_Water_piona")
            {
                GameObject instantiatedUnit = Instantiate(units[10], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "3_Dark_kamyum")
            {
                GameObject instantiatedUnit = Instantiate(units[11], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "3_Light Fire_reulloreu")
            {
                GameObject instantiatedUnit = Instantiate(units[12], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "3_Light Ground_illekto")
            {
                GameObject instantiatedUnit = Instantiate(units[13], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Unit.imageSlots[index].sprite.name == "5_Air_Ground_link")
            {
                GameObject instantiatedUnit = Instantiate(units[14], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Waits.transform.childCount > 0)
                {
                    Unit.imageSlots[index].sprite = null;
                }
                if (Unit.imageSlots[index].sprite == null)
                {
                    return;
                }
            }
        }
    }
}