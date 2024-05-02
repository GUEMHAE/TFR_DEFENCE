using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수
    public bool isGameOver = false; //게임오버 여부 판단
    public Text scoreText;
    public GameObject gameoverUI;
    public GameObject enemyPool; //적들이 들어 있는 부모 오브젝트를 등록하기 위한 GameObject

    private int score = 0;

    bool isTimeMultyply; //시간 배속 여부 

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

    public void CheckGameOver()  //게임 오버 체크
    {
        if(enemyPool.transform.childCount>=1)
        {
            isGameOver = true;
        }
    }
}
