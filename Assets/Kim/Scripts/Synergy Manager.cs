using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynergyManager : MonoBehaviour
{
    public struct Synergy //�ó������� ������ ��� ���� ���� Ŭ����
    {
        public string name; //�ó��� �̸�
        public Sprite icon; //�ó��� ������
        public string effect; //�ó��� ȿ�� ����
        [SerializeField]
        public int grade; //�ó��� ���(����)
    }

    [SerializeField]
    public Synergy[] synergies = new Synergy[6]; //�ó��� ����ü �迭

    private void Awake()
    {
        Init_Light();
        Init_Dark();
        Init_Water();
        Init_Fire();
        Init_Ground();
        Init_Air();
    }

    private void Start()
    {

    }

    void Update()
    {

    }

    void Init_Light()
    {
        synergies[0].name = "�ż�";
        synergies[0].effect = "1 �ó��� : �� �� ���� ȸ���� 1����\n2 �ó��� : �� �� ���� ȸ���� 2����\n3 �ó��� : �� �� ���� ȸ���� 3.5����\n4 �ó��� : �� �� ���� ȸ���� 5����\n5 �ó��� : �� �� ���� ȸ���� 8����";
        synergies[0].grade = 0;
        synergies[0].icon = Resources.Load<Sprite>("Synergy/Light"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Dark()
    {
        synergies[1].name = "�Ͽ�";
        synergies[1].effect = "1 �ó��� : �߰� ���� ���� 5%\n2 �ó��� : �߰� ���� ���� 15%\n3 �ó��� : �߰� ���� ���� 30%\n4 �ó��� : �߰� ���� ���� 50%";
        synergies[1].grade = 5;
        synergies[1].icon = Resources.Load<Sprite>("Synergy/Dark"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Water()
    {
        synergies[2].name = "���";
        synergies[2].effect = "1 �ó��� : �ֹ��� 20���� 5%\n2 �ó��� : �ֹ��� 50����\n3 �ó��� : �ֹ��� 100����\n4 �ó��� : �ֹ��� 200����";
        synergies[2].grade = 3;
        synergies[2].icon = Resources.Load<Sprite>("Synergy/Water"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Fire()
    {
        synergies[3].name = "Ȳȥ";
        synergies[3].effect = "1 �ó��� : ���ݷ� 20���� 5%\n2 �ó��� : ���ݷ� 50����\n3 �ó��� : ���ݷ� 100����\n4 �ó��� : ���ݷ� 200����";
        synergies[3].grade = 4;
        synergies[3].icon = Resources.Load<Sprite>("Synergy/Fire"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Ground()
    {
        synergies[4].name = "�ٿ�";
        synergies[4].effect = "1 �ó��� : ���� ���� �� ���� ���°� �������׷� 3���� 5%\n2 �ó��� : ���� ���� �� ���� ���°� �������׷� 8����\n3 �ó��� : ���� ���� �� ���� ���°� �������׷� 16����\n4 �ó��� : ���� ���� �� ���� ���°� �������׷� 30����";
        synergies[4].grade = 0;
        synergies[4].icon = Resources.Load<Sprite>("Synergy/Ground"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }

    void Init_Air()
    {
        synergies[5].name = "õ��";
        synergies[5].effect = "1 �ó��� : ���� �ӵ� 30%����\n\n ���忡 �ٶ� �Ӽ� ������ 2��ü ������ �� �ó��� ȿ���� ������ϴ�.";
        synergies[5].grade = 0;
        synergies[5].icon = Resources.Load<Sprite>("Synergy/Air"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ����
    }
}
