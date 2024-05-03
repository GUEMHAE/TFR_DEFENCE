using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectUI : MonoBehaviour
{
    Image img;
    public Sprite[] sprites;
    public TMP_Text name;
    public TMP_Text unitInfo;
    public TMP_Text SynergyText1;
    public TMP_Text SynergyText2;
    public Image classLogo;
    public Sprite[] classLogos;

    public Image Synergy1;
    public GameObject _Synergy2;
    public Sprite[] Synergys;
    public Image Synergy2;
    public int currentSprite = 0;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = sprites[currentSprite];
    }

    public void Update()
    {
        switch (currentSprite) 
        {
            case 0:
                name.text = "아록스";
                unitInfo.text = "공격력 0\n" +
                    "주문력 50\n" +
                    "공격속도 0.7\n" +
                    "스킬: 화염 소용돌이\n";
                classLogo.sprite = classLogos[0];
                _Synergy2.SetActive(true);
                Synergy1.sprite = Synergys[0];
                Synergy2.sprite = Synergys[2];

                SynergyText1.text = "천공";
                SynergyText2.text = "황혼";
                PlayerPrefs.SetInt("Character", 1);
                break;
            case 1:
                name.text = "토니르";
                unitInfo.text = "공격력 50\n" +
                    "주문력 0\n" +
                    "공격속도 1\n" +
                    "스킬: 신성의 검\n";
                classLogo.sprite = classLogos[0];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[1];
                SynergyText1.text = "신성";
                PlayerPrefs.SetInt("Character", 5);
                break;
            case 2:
                name.text = "바바리안";
                unitInfo.text = "공격력 60\n" +
                    "주문력 0\n" +
                    "공격속도 1.2\n" +
                    "스킬: 암석던지기\n";
                classLogo.sprite = classLogos[0];
                Synergy1.sprite = Synergys[4];
                SynergyText1.text = "근원";
                _Synergy2.SetActive(false);
                PlayerPrefs.SetInt("Character", 3);
                break;
            case 3:
                name.text = "다르밤";
                unitInfo.text = "공격력 40\n" +
                    "주문력 0\n" +
                    "공격속도 1.1\n" +
                    "스킬: 압정 깔기\n";
                classLogo.sprite = classLogos[3];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[1];
                SynergyText1.text = "암영";
                PlayerPrefs.SetInt("Character", 0);
                break;
            case 4:
                name.text = "애쉬";
                unitInfo.text = "공격력 0\n" +
                    "주문력 40\n" +
                    "공격속도 1.1\n" +
                    "스킬: 삼중 화살\n";
                classLogo.sprite = classLogos[1];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[5];
                SynergyText1.text = "기원";
                PlayerPrefs.SetInt("Character", 6);
                break;
            case 5:
                name.text = "스넬";
                unitInfo.text = " 공격력 0\n" +
                    "주문력 45\n" +
                    "공격속도 0.9\n" +
                    "스킬: 물의 숨결\n";
                classLogo.sprite = classLogos[2];
                _Synergy2.SetActive(true);
                Synergy1.sprite = Synergys[4];
                SynergyText1.text = "신성";
                Synergy2.sprite = Synergys[5];
                SynergyText2.text = "기원";
                PlayerPrefs.SetInt("Character", 4);
                break;
            case 6:
                name.text = "부르\n";
                unitInfo.text = "공격력 40\n'" +
                    "주문력 0\n" +
                    "공격속도 1\n" +
                    "스킬: 파이어 락\n";
                classLogo.sprite = classLogos[2];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[2];
                SynergyText1.text = "황혼";
                PlayerPrefs.SetInt("Character", 2);
                break;
        }
    }

    public void nextSprite()
    {
        if (img.sprite == sprites[6])
        {
            currentSprite = -1;
        }
        currentSprite++;


        Debug.Log(currentSprite);
        img.sprite = sprites[currentSprite];
    }

    public void frontSprite()
    {
        if (img.sprite == sprites[0])
        {
            currentSprite = sprites.Length;
        }
        currentSprite--;
        Debug.Log(currentSprite);
        img.sprite = sprites[currentSprite];
    }

    public void loadGameScene()
    {
        SceneManager.LoadScene("game");
    }
}
