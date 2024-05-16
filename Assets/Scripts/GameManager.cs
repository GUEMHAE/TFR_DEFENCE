using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����
    public bool isGameOver = false; //���ӿ��� ���� �Ǵ�
    public GameObject gameoverUI;
    public GameObject enemyPool; //������ ��� �ִ� �θ� ������Ʈ�� ����ϱ� ���� GameObject
    public int gold;
    public Text Multyply;


    bool isTimeMultyply; //�ð� ��� ���� 

    public void MultyplySpeed()
    {
        if (isTimeMultyply == false)
        {
            Time.timeScale = 2f;
            Multyply.text = ">>";
            isTimeMultyply = true;
        }
        else if (isTimeMultyply == true)
        {
            Time.timeScale = 1f;
            Multyply.text = ">";
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
        if (gameObject.scene.name == "Tutorial")
        {
            gold = 7;
        }
        else if (gameObject.scene.name == "Game")
        {
            gold = 4;
        }
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

    public void CheckGameOver()  //���� ���� üũ
    {
        if (enemyPool.transform.childCount >= 1)
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
