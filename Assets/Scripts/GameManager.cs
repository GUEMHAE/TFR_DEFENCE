using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����
    public bool isGameOver = false;
    public Text scoreText;
    public GameObject gameoverUI;
    [SerializeField]
    GameObject enemyPool; //������ ��� �ִ� �θ� ������Ʈ�� ����ϱ� ���� GameObject

    private int score = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       
    }

    void Update()
    {
        if (Round.instance.isRound == false)
        {
            CheckGameOver();
        }

        if (isGameOver)
        {
            gameoverUI.SetActive(true);
        }

    }
    public void AddScore(int newScore)
    {
        if (isGameOver)
        {
            score += newScore;
        }
    }

    public void CheckGameOver()  //���� ���� üũ
    {
        if(enemyPool.transform.childCount>=1)
        {
            isGameOver = true;
        }
    }
}
