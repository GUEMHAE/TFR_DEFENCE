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

    public static MergeManager instance; //�̱��� ����

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
            if (unitName.Substring(0, 2) == "1��")
            {
                if (countMap.ContainsKey(unitName))
                {
                    countMap[unitName]++;
                    Debug.Log("1�ڽ�Ʈ ���� �Ѹ��� �߰�");
                    Debug.Log(countMap);
                }
                else
                {
                    countMap[unitName] = 1;
                    Debug.Log("1�ڽ�Ʈ ���� ���� �Ѹ���");
                }
            }
        }

        foreach (KeyValuePair<string, int> pair in countMap)
        {
            if (pair.Value == 3)
            {
                foreach (GameObject unit in allUnits)
                {
                    if (unit.name.Substring(0, 2) == "1��")
                    {
                        if (unit.name == pair.Key)
                        {
                            Debug.Log("1�ڽ�Ʈ ���� ���� 3����" + " : " + pair.Key);

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

                            if (unitGrade.Contains("1��"))
                            {
                                GameObject upgrade2Unit = Instantiate(unit, allUnits[idx].transform.position, Quaternion.identity);
                                upgrade2Unit.transform.SetParent(unit.transform.parent);
                                changeGrade = upgrade2Unit.name.Substring(0, 2).Replace("1��", "2��");
                                upgrade2Unit.name = changeGrade + unitName;
                                upgrade2Unit.transform.localScale = originScale;
                                Instantiate(unitUpgrade2Particle, allUnits[idx].transform.position, Quaternion.identity);
                                Debug.Log("2�� ���׷��̵�");
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
            if (unitName.Substring(0, 2) == "2��")
            {
                if (countMap.ContainsKey(unitName))
                {
                    countMap[unitName]++;
                    Debug.Log("2�ڽ�Ʈ ���� �Ѹ��� �߰�");
                    Debug.Log(countMap);
                }
                else
                {
                    countMap[unitName] = 1;
                    Debug.Log("2�ڽ�Ʈ ���� ���� �Ѹ���");
                }
            }
        }

        foreach (KeyValuePair<string, int> pair in countMap)
        {
            if (pair.Value == 3)
            {
                foreach (GameObject unit in allUnits)
                {
                    if (unit.name.Substring(0, 2) == "2��")
                    {
                        if (unit.name == pair.Key)
                        {
                            Debug.Log("2�ڽ�Ʈ ���� ���� 3����" + " : " + pair.Key);

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

                            if (unitGrade.Contains("2��"))
                            {
                                GameObject upgrade3Unit = Instantiate(unit, allUnits[idx].transform.position, Quaternion.identity);
                                upgrade3Unit.transform.SetParent(unit.transform.parent);
                                changeGrade = upgrade3Unit.name.Substring(0, 2).Replace("2��", "3��");
                                upgrade3Unit.name = changeGrade + unitName;
                                upgrade3Unit.transform.localScale = originScale;
                                Instantiate(unitUpgrade2Particle, allUnits[idx].transform.position, Quaternion.identity);
                                Debug.Log("3�� ���׷��̵�");
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
