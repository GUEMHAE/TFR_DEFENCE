using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLimitManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> allUnits; //���� ����Ʈ
    [SerializeField]
    List<GameObject> allGrid; //�׸��� ����Ʈ

    [SerializeField]
    int unitCount; //�׸��� ���� �ִ� ������ �� ���� ����

    UnitLimitManager instance;

    public void GetOnlyGridUnits()
    {
        allUnits.Clear();

        foreach (GameObject Grid in allGrid)
        {
            foreach (Transform child in Grid.transform)
            {
                if (child != Grid.transform)
                {
                    allUnits.Add(child.gameObject); //�׸��� ���� �ڽ� ������Ʈ�� �޾Ƽ� allUnit(���� ����Ʈ)�� �߰�
                }
            }
        }
    }

    private void Awake()
    {
        if(instance==null)
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
        unitCount = allUnits.Count;
        Debug.Log(unitCount);
    }
}
