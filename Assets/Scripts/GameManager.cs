using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수
    public bool isGameOver = false; //게임오버 여부 판단
    public GameObject gameoverUI;
    public GameObject enemyPool; //적들이 들어 있는 부모 오브젝트를 등록하기 위한 GameObject
    public GameObject unitinfoUI;
    public GameObject WinUI;
    public int gold;
    public Text Multyply;


    bool isTimeMultyply; //시간 배속 여부 

    public void MultyplySpeed()
    {
        if (isTimeMultyply == false)
        {
            Time.timeScale = 2f;
            Multyply.text = "x2";
            isTimeMultyply = true;
        }
        else if (isTimeMultyply == true)
        {
            Time.timeScale = 1f;
            Multyply.text = "x1";
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
        RandomSprite_Unit.instance.RoundRandomSprite();

        if (gameObject.scene.name == "Tutorial")
        {
            gold = 5;
        }
        else if (gameObject.scene.name == "Game")
        {
            gold = 2;
        }
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
            unitinfoUI.SetActive(false);
            Round.instance.enabled = false;
        }

        if (Round.instance.currentRound == 20 && Round.instance.isRound == false&&enemyPool.transform.childCount==0)
        {
            WinUI.SetActive(true);
        }
        else
        {
            WinUI.SetActive(false);
        }
    }

    public void CheckGameOver()  //게임 오버 체크
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
