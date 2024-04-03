using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyManager : MonoBehaviour
{
    [SerializeField]
    public struct Synergy //�ó������� ������ ��� ���� ���� Ŭ����
    {
        public string name; //�ó��� �̸�
        public Sprite icon;  //�ó��� ������
        public string effect; //�ó��� ȿ�� ����
        public int grade; //�ó��� ���(����)
    }
    
    public Synergy synergie1; //�ó��� ����ü
    public Synergy synergie2; 
    public Synergy synergie3; 
    public Synergy synergie4; 
    public Synergy synergie5; 
    public Synergy synergie6;

    private void Awake()
    {
        synergie1 = new Synergy(); //�ż� �ó���
        synergie2 = new Synergy(); //�Ͽ� �ó���
        synergie3 = new Synergy(); //��� �ó���
        synergie4 = new Synergy(); //Ȳȥ �ó���
        synergie5 = new Synergy(); //�ٿ� �ó���
        synergie6 = new Synergy(); //õ�� �ó���

        Init_Light();
        Init_Dark();
        Init_Water();
        Init_Fire();
        Init_Ground();
        Init_Air();
    }

    void Update()
    {
        
    }

    void Init_Light()
    {
        synergie1.name = "�ż�";
        synergie1.icon = Resources.Load<Sprite>("��¡/�ż�"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ���� 
        synergie1.effect = "1 �ó��� : �� �� ���� ȸ���� 1����\n2 �ó��� : �� �� ���� ȸ���� 2����\n3 �ó��� : �� �� ���� ȸ���� 3.5����\n4 �ó��� : �� �� ���� ȸ���� 5����\n5 �ó��� : �� �� ���� ȸ���� 8����";
        synergie1.grade = 0;
    }

    void Init_Dark()
    {
        synergie2.name = "�Ͽ�";
        synergie2.icon = Resources.Load<Sprite>("��¡/�Ͽ�"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ���� 
        synergie2.effect = "1 �ó��� : �߰� ���� ���� 5%\n2 �ó��� : �߰� ���� ���� 15%\n3 �ó��� : �߰� ���� ���� 30%\n4 �ó��� : �߰� ���� ���� 50%";
        synergie2.grade = 0;
    }

    void Init_Water()
    {
        synergie3.name = "���";
        synergie3.icon = Resources.Load<Sprite>("��¡/���"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ���� 
        synergie3.effect = "1 �ó��� : �ֹ��� 20���� 5%\n2 �ó��� : �ֹ��� 50����\n3 �ó��� : �ֹ��� 100����\n4 �ó��� : �ֹ��� 200����";
        synergie3.grade = 0;
    }

    void Init_Fire()
    {
        synergie4.name = "Ȳȥ";
        synergie4.icon = Resources.Load<Sprite>("��¡/Ȳȥ"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ���� 
        synergie4.effect = "1 �ó��� : ���ݷ� 20���� 5%\n2 �ó��� : ���ݷ� 50����\n3 �ó��� : ���ݷ� 100����\n4 �ó��� : ���ݷ� 200����";
        synergie4.grade = 0;
    }

    void Init_Ground()
    {
        synergie5.name = "�ٿ�";
        synergie5.icon = Resources.Load<Sprite>("��¡/�ٿ�"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ���� 
        synergie5.effect = "1 �ó��� : ���� ���� �� ���� ���°� �������׷� 3���� 5%\n2 �ó��� : ���� ���� �� ���� ���°� �������׷� 8����\n3 �ó��� : ���� ���� �� ���� ���°� �������׷� 16����\n4 �ó��� : ���� ���� �� ���� ���°� �������׷� 30����";
        synergie5.grade = 0;
    }

    void Init_Air()
    {
        synergie6.name = "õ��";
        synergie6.icon = Resources.Load<Sprite>("��¡/õ��"); //���ҽ� �̸��� ""���̿� ������ ������ ���� ���� 
        synergie6.effect = "1 �ó��� : ���� �ӵ� 30%����\n\n ���忡 �ٶ� �Ӽ� ������ 2��ü ������ �� �ó��� ȿ���� ������ϴ�.";
        synergie6.grade = 0;
    }
}
