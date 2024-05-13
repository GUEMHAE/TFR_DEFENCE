using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLimitManager : MonoBehaviour
{
    public List<GameObject> allUnits; //���� ����Ʈ
    [SerializeField]
    List<GameObject> allGrid; //�׸��� ����Ʈ

    public int curUnitCount; //�׸��� ���� �ִ� ������ �� ���� ����

    public int MaxunitCount = 7;

    public static UnitLimitManager instance;

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
        curUnitCount = allUnits.Count;
    }
}
