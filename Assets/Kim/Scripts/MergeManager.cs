using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MergeManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> allUnits;
    [SerializeField]
    List<GameObject> allGrid;

    [SerializeField]
    GameObject unitUpgrade2Particle;

    public static MergeManager instance; //싱글톤 패턴

    public void GetGridUnits()
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

    public GameObject CheckFor1CostUnitCount()
    {
        GetGridUnits();

        Dictionary<string, int> countMap = new Dictionary<string, int>();

        foreach (GameObject unit in allUnits)
        {
            string unitName = unit.name;
            if (unitName.Substring(0, 2) == "1성")
            {
                if (countMap.ContainsKey(unitName))
                {
                    countMap[unitName]++;
                    Debug.Log("1코스트 유닛 한마리 추가");
                    Debug.Log(countMap);
                }
                else
                {
                    countMap[unitName] = 1;
                    Debug.Log("1코스트 동일 유닛 한마리");
                }
            }
        }

        foreach (KeyValuePair<string, int> pair in countMap)
        {
            if (pair.Value == 3)
            {
                foreach (GameObject unit in allUnits)
                {
                    if (unit.name.Substring(0, 2) == "1성")
                    {
                        if (unit.name == pair.Key)
                        {
                            Debug.Log("1코스트 동일 유닛 3마리" + " : " + pair.Key);

                            allUnits = allUnits.OrderBy(obj => obj.name).ToList();
                            int idx = allUnits.IndexOf(unit);
                            Debug.Log(idx.ToString());

                            Vector3 originScale = unit.transform.localScale;

                            Destroy(allUnits[idx + 2]);
                            allUnits.RemoveAt(idx + 2);
                            Destroy(allUnits[idx + 1]);
                            allUnits.RemoveAt(idx + 1);

                            string unitGrade = unit.name.Substring(0, 2);
                            string unitName = unit.name.Substring(2);
                            string changeGrade = unitGrade;

                            if (unitGrade.Contains("1성"))
                            {
                                GameObject upgrade2Unit = Instantiate(unit, allUnits[idx].transform.position, Quaternion.identity);
                                upgrade2Unit.transform.SetParent(unit.transform.parent);
                                changeGrade = upgrade2Unit.name.Substring(0, 2).Replace("1성", "2성");
                                upgrade2Unit.name = changeGrade + unitName;
                                upgrade2Unit.transform.localScale = originScale;
                                Instantiate(unitUpgrade2Particle, allUnits[idx].transform.position, Quaternion.identity);
                                Debug.Log("2성 업그레이드");
                            }
                            Destroy(allUnits[idx]);
                            Debug.Log(allUnits);
                            return unit;
                        }
                    }
                }
            }
        }
        return null;
    }

    public GameObject CheckFor2CostUnitCount()
    {
        GetGridUnits();

        Dictionary<string, int> countMap = new Dictionary<string, int>();

        foreach (GameObject unit in allUnits)
        {
            string unitName = unit.name;
            if (unitName.Substring(0, 2) == "2성")
            {
                if (countMap.ContainsKey(unitName))
                {
                    countMap[unitName]++;
                    Debug.Log("2코스트 유닛 한마리 추가");
                    Debug.Log(countMap);
                }
                else
                {
                    countMap[unitName] = 1;
                    Debug.Log("2코스트 동일 유닛 한마리");
                }
            }
        }

        foreach (KeyValuePair<string, int> pair in countMap)
        {
            if (pair.Value == 3)
            {
                foreach (GameObject unit in allUnits)
                {
                    if (unit.name.Substring(0, 2) == "2성")
                    {
                        if (unit.name == pair.Key)
                        {
                            Debug.Log("2코스트 동일 유닛 3마리" + " : " + pair.Key);

                            allUnits = allUnits.OrderBy(obj => obj.name).ToList();
                            int idx = allUnits.IndexOf(unit);
                            Debug.Log(idx.ToString());

                            Vector3 originScale = unit.transform.localScale;

                            Destroy(allUnits[idx + 2]);
                            allUnits.RemoveAt(idx + 2);
                            Destroy(allUnits[idx + 1]);
                            allUnits.RemoveAt(idx + 1);

                            string unitGrade = unit.name.Substring(0, 2);
                            string unitName = unit.name.Substring(2);
                            string changeGrade = unitGrade;

                            if (unitGrade.Contains("2성"))
                            {
                                GameObject upgrade3Unit = Instantiate(unit, allUnits[idx].transform.position, Quaternion.identity);
                                upgrade3Unit.transform.SetParent(unit.transform.parent);
                                changeGrade = upgrade3Unit.name.Substring(0, 2).Replace("2성", "3성");
                                upgrade3Unit.name = changeGrade + unitName;
                                upgrade3Unit.transform.localScale = originScale;
                                Instantiate(unitUpgrade2Particle, allUnits[idx].transform.position, Quaternion.identity);
                                Debug.Log("3성 업그레이드");
                            }
                            Destroy(allUnits[idx]);
                            Debug.Log(allUnits);
                            return unit;
                        }
                    }
                }
            }
        }
        return null;
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

        GetGridUnits();
    }
}
