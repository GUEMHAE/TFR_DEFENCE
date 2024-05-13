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

    Vector3 waitUnitScale = new Vector3(0.8f, 0.8f, 1);

    public bool canBuy;

    private void Start()
    {       
        Unit = GetComponent<RandomSprite_Unit>();
        GameObject instance = Instantiate(units[PlayerPrefs.GetInt("Character")]);
        instance.transform.SetParent(grid.transform);
        instance.name = instance.name.Substring(0,instance.name.Length-7);
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
            if (Unit.imageSlots[index].sprite.name == "1_Dark_dareubam" && GameManager.instance.gold >=1)
            {
                GameObject instantiatedUnit = Instantiate(units[0], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 다르밤_암영1";
                GameManager.instance.gold -= 1;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "1_Fire_arokseu"&&GameManager.instance.gold >= 1)
            {
                GameObject instantiatedUnit = Instantiate(units[1], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 아록스_천공1,황혼2";
                GameManager.instance.gold -= 1;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "1_Fire_bureu"&&GameManager.instance.gold >= 1)
            {
                GameObject instantiatedUnit = Instantiate(units[2], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 부르_황혼1";
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "1_Ground_babarian"&&GameManager.instance.gold >= 1)
            {
                GameObject instantiatedUnit = Instantiate(units[3], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 바바리안_근원1";
                GameManager.instance.gold -= 1;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "1_Light_Water_seunel"&&GameManager.instance.gold >= 1)
            {
                GameObject instantiatedUnit = Instantiate(units[4], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 스넬_신성1,기원1";
                GameManager.instance.gold -= 1;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }


            if (Unit.imageSlots[index].sprite.name == "1_Light_tonireu"&&GameManager.instance.gold >= 1)
            {
                GameObject instantiatedUnit = Instantiate(units[5], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 토니르_신성2";
                GameManager.instance.gold -= 1;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }


            if (Unit.imageSlots[index].sprite.name == "1_Water_aeswi"&&GameManager.instance.gold >= 1)
            {
                GameObject instantiatedUnit = Instantiate(units[6], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 애쉬_기원2";
                GameManager.instance.gold -= 1;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }


            if (Unit.imageSlots[index].sprite.name == "2_Dark_aseoseu"&&GameManager.instance.gold >= 2)
            {
                GameObject instantiatedUnit = Instantiate(units[7], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 아서스_암영2";
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "2_Ground_areute"&&GameManager.instance.gold >= 2)
            {
                GameObject instantiatedUnit = Instantiate(units[8], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 아르테_근원2";
                GameManager.instance.gold -= 2;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "2_Light Dark_ireusigeu" && GameManager.instance.gold >= 2)
            {
                GameObject instantiatedUnit = Instantiate(units[9], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 이르시그_신성3,암영3";
                GameManager.instance.gold -= 2;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "2_Water_piona" && GameManager.instance.gold >= 2)
            {
                GameObject instantiatedUnit = Instantiate(units[10], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 피오나_기원3";
                GameManager.instance.gold -= 2;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "3_Dark_kamyum" && GameManager.instance.gold >= 3)
            {
                GameObject instantiatedUnit = Instantiate(units[11], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 카뮴_암영3,기원4";
                GameManager.instance.gold -= 3;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "3_Light Fire_reulloreu" && GameManager.instance.gold >= 3)
            {
                GameObject instantiatedUnit = Instantiate(units[12], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 를로르_신성4,황혼3";
                GameManager.instance.gold -= 3;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "3_Light Ground_illekto" && GameManager.instance.gold >= 3)
            {
                GameObject instantiatedUnit = Instantiate(units[13], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 일렉토_신성5,근원3";
                GameManager.instance.gold -= 3;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
            }

            if (Unit.imageSlots[index].sprite.name == "5_Air_Ground_link" && GameManager.instance.gold >= 5)
            {
                GameObject instantiatedUnit = Instantiate(units[14], Waits.transform.position, Quaternion.identity);
                instantiatedUnit.transform.SetParent(Waits.transform);
                instantiatedUnit.transform.localScale = waitUnitScale;
                instantiatedUnit.name = "1성 링크_천공2,근원4";
                GameManager.instance.gold -= 5;
                MergeManager.instance.CheckFor1CostUnitCount();
                MergeManager.instance.CheckFor2CostUnitCount();
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