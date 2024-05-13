using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����
    public bool isGameOver = false; //���ӿ��� ���� �Ǵ�
    public Text scoreText;
    public GameObject gameoverUI;
    public GameObject enemyPool; //������ ��� �ִ� �θ� ������Ʈ�� ����ϱ� ���� GameObject
    public int gold;

    private int score = 0;

    bool isTimeMultyply; //�ð� ��� ���� 

    public void MultyplySpeed()
    {
        if (isTimeMultyply == false)
        {
            Time.timeScale = 2f;
            isTimeMultyply = true;
        }
        else if(isTimeMultyply==true)
        {
            Time.timeScale = 1f;
            isTimeMultyply = false;
        }
    }

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
    gold = 2;
    RandomSprite_Unit.instance.RandomSprite();
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
            Round.instance.enabled = false;
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

    public void GameOver_Title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void GameOver_Quit()
    {
        Application.Quit();
    }
}
