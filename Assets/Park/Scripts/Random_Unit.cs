using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Unit : MonoBehaviour
{
    public int[] index; // 랜덤 인덱스 저장 배열
    public int ranIndexes = 4; // 저장할 랜덤 인덱스의 수
    public GameObject[] units; // 유닛 프리팹
    private int cost1_count = 0;
    private int cost2_count = 0;
    private int cost3_count = 0;
    private int cost5_count = 0;

    public int level = 1;

    private bool canBuy = false;

    void Start()
    {
        RandomPool(); // 게임이 시작될 때 랜덤 유닛 생성
    }

    // Update is called once per frame
    void Update()
    {
        // 원하는 경우 특정 조건에 따라 랜덤 유닛을 생성할 수 있음
    }

    //0~6까지는 최대 17개 까지 나올 수 있고  7~10까지는 14개 11~13는 11개 14는 1개
    public void RandomPool()
    {
        index = new int[ranIndexes]; // 인덱스 배열 초기화

        // 코스트 별 카운트 초기화
        cost1_count = 0;
        cost2_count = 0;
        cost3_count = 0;
        cost5_count = 0;

        for (int i = 0; i < ranIndexes; i++)
        {
            // 레벨에 따른 확률로 랜덤 인덱스 생성
            if (level == 1)
            {
                // 1코 확률 100 2코 0 3코 0 4코 0 
                index[i] = Random.Range(0, 7);
            }
            else if (level == 2)
            {
                // 1코 확률 90 2코 10 3코 0 4코 0 
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
                // 1코 확률 75 2코 20 3코 5 4코 0 
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
                // 1코 확률 55 2코 35 3코 10 4코 0 
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
                // 1코 확률 30 2코 40 3코 30 4코 0 
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
                // 1코 확률 10 2코 30 3코 40 4코 20
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

            // 코스트 별 카운트 증가
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

        return canBuy; // 특정 조건에 따라 변경해야 함
    }
}
