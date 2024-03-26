using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyManager : MonoBehaviour
{
    public int light_num;           //��(���� ȸ��) �ó����� ����
    public int dark_num;           //���(�߰� ���� ����) �ó����� ����
    public int water_num;         //��(�ֹ��� ����) �ó����� ����
    public int fire_num;            //��(�� �� �߰� ������)�ó����� ����
    public int ground_num;      //��(����,�������׷� ����)�ó����� ����
    public int air_num;            //�ٶ�(���ݼӵ� ����,�ܰ迡 ���� �ó��� ȿ�� ����)�ó����� ����

    public float manaregen=2; //�ʱ� ���� ȸ����

    void Start()
    {
        
    }

    void Update()
    {
        switch(light_num)        //�� �ó����� ������ ���� ���� ȸ�� ����
        {
            case 0: 
                break;
            case 1:
                break;
            case 2:
                manaregen =2.5f;
                break;
            case 3:
                manaregen =3.5f;
                break;
            case 4:
                manaregen = 5f;
                break;
            case 5:
                manaregen = 7;
                break;
            default:
                break;
        }
    }
}
