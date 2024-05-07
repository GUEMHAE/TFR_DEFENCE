using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Cysharp.Threading.Tasks;
using System;

public class SynergyManager : MonoBehaviour
{
    public struct Synergy //�ó������� ������ ��� ���� ���� Ŭ����
    {
        public string name; //�ó��� �̸�
        public Sprite icon; //�ó��� ������
        public string effect; //�ó��� ȿ�� ����
        public int grade; //�ó��� ���(����)
    }
    public List<string> unitName;


    [SerializeField]
    public Synergy[] synergies = new Synergy[6]; //�ó��� ����ü �迭

    [SerializeField]
    private Transform[] grid;

    static public SynergyManager instance;

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
        Init_Light();
        Init_Dark();
        Init_Water();
        Init_Fire();
        Init_Ground();
        Init_Air();
    }

    private void Start()
    {
        SynergyOnField.instance.allUnits = RemoveDuplicates(SynergyOnField.instance.allUnits);
        checkSynergy().Forget();
    }

    void Update()
    {
        Debug.Log(synergies[1].grade);
    }

    async UniTaskVoid checkSynergy()
    {
        int previousListLength = SynergyOnField.instance.allUnits.Count; // ó���� ���� ����Ʈ�� ���� ����
        while (true)
        {
            await UniTask.WaitUntil(() =>
            {
                // ���� ����Ʈ�� ���̿� ���� ����Ʈ�� ���̸� ���Ͽ� ��ȭ�� ����
                int currentListLength = SynergyOnField.instance.allUnits.Count;
                if (currentListLength != previousListLength)
                {
                    // ����Ʈ�� ���̰� �������� ��
                    if (currentListLength > previousListLength)
                    {
                        Debug.Log("List length increased!");
                        IncreaseSynergy();
                    }
                    // ����Ʈ�� ���̰� �������� ��
                    else
                    {
                        Debug.Log("List length decreased!");
                    }

                    previousListLength = currentListLength; // ����� ����Ʈ�� ���̷� ������Ʈ
                    return true; // ����Ǿ����� ��� ����
                }
                return false; // ������� �ʾ����� ��� ���
            });
        }
    }

    void Init_Light()
    {
        synergies[0].name = "�ż�";
        synergies[0].effect = "1 �ó��� : �� �� ���� ȸ���� 1����\n2 �ó��� : �� �� ���� ȸ���� 2����\n3 �ó��� : �� �� ���� ȸ���� 3.5����\n4 �ó��� : �� �� ���� ȸ���� 5����\n5 �ó��� : �� �� ���� ȸ���� 8����";
        synergies[0].grade = 0;
        synergies[0].icon = Resources.Load<Sprite>("Symbol/Light"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Dark()
    {
        synergies[1].name = "�Ͽ�";
        synergies[1].effect = "1 �ó��� : �߰� ���� ���� 5%\n2 �ó��� : �߰� ���� ���� 15%\n3 �ó��� : �߰� ���� ���� 30%\n4 �ó��� : �߰� ���� ���� 50%";
        synergies[1].grade = 0;
        synergies[1].icon = Resources.Load<Sprite>("Symbol/Dark"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Water()
    {
        synergies[2].name = "���";
        synergies[2].effect = "1 �ó��� : �ֹ��� 20���� 5%\n2 �ó��� : �ֹ��� 50����\n3 �ó��� : �ֹ��� 100����\n4 �ó��� : �ֹ��� 200����";
        synergies[2].grade = 0;
        synergies[2].icon = Resources.Load<Sprite>("Symbol/Water"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Fire()
    {
        synergies[3].name = "Ȳȥ";
        synergies[3].effect = "1 �ó��� : ���ݷ� 20���� 5%\n2 �ó��� : ���ݷ� 50����\n3 �ó��� : ���ݷ� 100����\n4 �ó��� : ���ݷ� 200����";
        synergies[3].grade = 0;
        synergies[3].icon = Resources.Load<Sprite>("Symbol/Fire"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Ground()
    {
        synergies[4].name = "�ٿ�";
        synergies[4].effect = "1 �ó��� : ���� ���� �� ���� ���°� �������׷� 3���� 5%\n2 �ó��� : ���� ���� �� ���� ���°� �������׷� 8����\n3 �ó��� : ���� ���� �� ���� ���°� �������׷� 16����\n4 �ó��� : ���� ���� �� ���� ���°� �������׷� 30����";
        synergies[4].grade = 0;
        synergies[4].icon = Resources.Load<Sprite>("Symbol/Ground"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Air()
    {
        synergies[5].name = "õ��";
        synergies[5].effect = "1 �ó��� : ���� �ӵ� 30%����\n\n ���忡 �ٶ� �Ӽ� ������ 2��ü ������ �� �ó��� ȿ���� ������ϴ�.";
        synergies[5].grade = 0;
        synergies[5].icon = Resources.Load<Sprite>("Symbol/Air"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    public List<GameObject> RemoveDuplicates(List<GameObject> originalList)
    {
        List<GameObject> uniqueList = new List<GameObject>();

        foreach (GameObject obj in originalList)
        {
            // �� ����Ʈ�� ���� �̸��� ��Ұ� ������ �߰�
            if (!uniqueList.Any(item => item.name.Substring(3) == obj.name.Substring(3)))
            {
                uniqueList.Add(obj);
                //IncreaseSynergy();
            }
        }

        return uniqueList;
    }

    public Dictionary<string, int> GetSynergyCounts(Synergy[] synergies, List<GameObject> unitsOnField)
{
        Dictionary<string, int> synergyCountMap = new Dictionary<string, int>();

        // �� �ó����� �ʱ� ������ 0���� ����
        foreach (Synergy synergy in synergies)
        {
            synergyCountMap[synergy.name] = 0;
        }

        // �� ������ ��ȸ�ϸ鼭 �ó��� ������ ����
        foreach (GameObject unit in unitsOnField)
        {
            string unitName = unit.name;

            // �ó��� ����� ��ȸ�ϸ鼭 �ش� ������ � �ó����� ���ϴ��� Ȯ��
            foreach (Synergy synergy in synergies)
            {
                if (unitName.Contains(synergy.name)) // ���� �̸��� �ó��� �̸��� ���ԵǾ� �ִ��� Ȯ��
                {
                    synergyCountMap[synergy.name]++;
                }
            }
        }

        return synergyCountMap;
    }


    public void IncreaseSynergy()
    {
        foreach (var unit in SynergyOnField.instance.allUnits)
        {
            
            Debug.Log(unit.name.Substring(3));
            switch (unit.name.Substring(3))
            {
                case "�ٸ���":
                    synergies[1].grade++;
                    break;
                case "�ٹٸ���":
                    synergies[4].grade++;
                    break;
                case "�θ�":
                    synergies[3].grade++;
                    break;
                case "����":
                    synergies[0].grade++;
                    synergies[2].grade++;
                    break;
                case "�ƷϽ�":
                    synergies[3].grade++;
                    synergies[5].grade++;
                    break;
                case "�ֽ�":
                    synergies[2].grade++;
                    break;
                case "��ϸ�":
                    synergies[0].grade++;
                    break;
                case "�Ƹ���":
                    synergies[4].grade++;
                    break;
                case "�Ƽ���":
                    synergies[1].grade++;
                    break;
                case "�̸��ñ�":
                    synergies[0].grade++;
                    synergies[1].grade++;
                    break;
                case "�ǿ���":
                    synergies[2].grade++;
                    break;
                case "���θ�":
                    synergies[0].grade++;
                    synergies[3].grade++;
                    break;
                case "�Ϸ���":
                    synergies[0].grade++;
                    synergies[4].grade++;
                    break;
                case "ī��":
                    synergies[1].grade++;
                    synergies[2].grade++;
                    break;
                case "��ũ":
                    synergies[4].grade++;
                    synergies[5].grade++;
                    break;
            }
        }
    }

}
