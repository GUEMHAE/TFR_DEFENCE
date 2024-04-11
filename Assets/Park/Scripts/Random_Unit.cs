using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Unit : MonoBehaviour
{
    public int[] index; // ���� �ε��� ���� �迭
    public int ranIndexes = 4; // ������ ���� �ε����� ��
    public GameObject[] units; // ���� ������
    private int cost1_count = 0;
    private int cost2_count = 0;
    private int cost3_count = 0;
    private int cost5_count = 0;

    public int level = 1;

    private bool canBuy = false;

    void Start()
    {
        RandomPool(); // ������ ���۵� �� ���� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        // ���ϴ� ��� Ư�� ���ǿ� ���� ���� ������ ������ �� ����
    }

    //0~6������ �ִ� 17�� ���� ���� �� �ְ�  7~10������ 14�� 11~13�� 11�� 14�� 1��
    public void RandomPool()
    {
        index = new int[ranIndexes]; // �ε��� �迭 �ʱ�ȭ

        // �ڽ�Ʈ �� ī��Ʈ �ʱ�ȭ
        cost1_count = 0;
        cost2_count = 0;
        cost3_count = 0;
        cost5_count = 0;

        for (int i = 0; i < ranIndexes; i++)
        {
            // ������ ���� Ȯ���� ���� �ε��� ����
            if (level == 1)
            {
                // 1�� Ȯ�� 100 2�� 0 3�� 0 4�� 0 
                index[i] = Random.Range(0, 7);
            }
            else if (level == 2)
            {
                // 1�� Ȯ�� 90 2�� 10 3�� 0 4�� 0 
                int randValue = Random.Range(0, 100);
                if (randValue < 90)
                {
                    index[i] = Random.Range(0, 7);
                }
                else
                {
                    index[i] = Random.Range(7, 11);
                }
            }
            else if (level == 3)
            {
                // 1�� Ȯ�� 75 2�� 20 3�� 5 4�� 0 
                int randValue = Random.Range(0, 100);
                if (randValue < 75)
                {
                    index[i] = Random.Range(0, 7);
                }
                else if (randValue < 95)
                {
                    index[i] = Random.Range(7, 11);
                }
                else
                {
                    index[i] = Random.Range(11, 14);
                }
            }
            else if (level == 4)
            {
                // 1�� Ȯ�� 55 2�� 35 3�� 10 4�� 0 
                int randValue = Random.Range(0, 100);
                if (randValue < 55)
                {
                    index[i] = Random.Range(0, 7);
                }
                else if (randValue < 90)
                {
                    index[i] = Random.Range(7, 11);
                }
                else
                {
                    index[i] = Random.Range(11, 14);
                }
            }
            else if (level == 5)
            {
                // 1�� Ȯ�� 30 2�� 40 3�� 30 4�� 0 
                int randValue = Random.Range(0, 100);
                if (randValue < 30)
                {
                    index[i] = Random.Range(0, 7);
                }
                else if (randValue < 70)
                {
                    index[i] = Random.Range(7, 11);
                }
                else
                {
                    index[i] = Random.Range(11, 14);
                }
            }
            else if (level == 6)
            {
                // 1�� Ȯ�� 10 2�� 30 3�� 40 4�� 20
                int randValue = Random.Range(0, 100);
                if (randValue < 10)
                {
                    index[i] = Random.Range(0, 7);
                }
                else if (randValue < 40)
                {
                    index[i] = Random.Range(7, 11);
                }
                else
                {
                    index[i] = Random.Range(11, 14);
                }
            }

            // �ڽ�Ʈ �� ī��Ʈ ����
            if (index[i] < 7)
            {
                cost1_count++;
            }
            else if (index[i] < 11)
            {
                cost2_count++;
            }
            else if (index[i] < 14)
            {
                cost3_count++;
            }
            else
            {
                cost5_count++;
            }
        }
    }

    public bool unitShop()
    {
        if (ranIndexes < 7)
        {
            if (cost1_count > 17)
            {
                return false;
            }
        }
        else if (7 <= ranIndexes && ranIndexes < 11)
        {
            if (cost2_count > 14)
            {
                return false;
            }
        }
        else if (11 <= ranIndexes && ranIndexes < 14)
        {
            if (cost3_count > 11)
            {
                return false;
            }
        }
        else if (ranIndexes == 14)
        {
            if (cost5_count > 9)
            {
                return false;
            }
        }

        return canBuy; // Ư�� ���ǿ� ���� �����ؾ� ��
    }
}
