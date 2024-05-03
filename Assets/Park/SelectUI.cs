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
                name.text = "�ƷϽ�";
                unitInfo.text = "���ݷ� 0\n" +
                    "�ֹ��� 50\n" +
                    "���ݼӵ� 0.7\n" +
                    "��ų: ȭ�� �ҿ뵹��\n";
                classLogo.sprite = classLogos[0];
                _Synergy2.SetActive(true);
                Synergy1.sprite = Synergys[0];
                Synergy2.sprite = Synergys[2];

                SynergyText1.text = "õ��";
                SynergyText2.text = "Ȳȥ";
                PlayerPrefs.SetInt("Character", 1);
                break;
            case 1:
                name.text = "��ϸ�";
                unitInfo.text = "���ݷ� 50\n" +
                    "�ֹ��� 0\n" +
                    "���ݼӵ� 1\n" +
                    "��ų: �ż��� ��\n";
                classLogo.sprite = classLogos[0];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[1];
                SynergyText1.text = "�ż�";
                PlayerPrefs.SetInt("Character", 5);
                break;
            case 2:
                name.text = "�ٹٸ���";
                unitInfo.text = "���ݷ� 60\n" +
                    "�ֹ��� 0\n" +
                    "���ݼӵ� 1.2\n" +
                    "��ų: �ϼ�������\n";
                classLogo.sprite = classLogos[0];
                Synergy1.sprite = Synergys[4];
                SynergyText1.text = "�ٿ�";
                _Synergy2.SetActive(false);
                PlayerPrefs.SetInt("Character", 3);
                break;
            case 3:
                name.text = "�ٸ���";
                unitInfo.text = "���ݷ� 40\n" +
                    "�ֹ��� 0\n" +
                    "���ݼӵ� 1.1\n" +
                    "��ų: ���� ���\n";
                classLogo.sprite = classLogos[3];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[1];
                SynergyText1.text = "�Ͽ�";
                PlayerPrefs.SetInt("Character", 0);
                break;
            case 4:
                name.text = "�ֽ�";
                unitInfo.text = "���ݷ� 0\n" +
                    "�ֹ��� 40\n" +
                    "���ݼӵ� 1.1\n" +
                    "��ų: ���� ȭ��\n";
                classLogo.sprite = classLogos[1];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[5];
                SynergyText1.text = "���";
                PlayerPrefs.SetInt("Character", 6);
                break;
            case 5:
                name.text = "����";
                unitInfo.text = " ���ݷ� 0\n" +
                    "�ֹ��� 45\n" +
                    "���ݼӵ� 0.9\n" +
                    "��ų: ���� ����\n";
                classLogo.sprite = classLogos[2];
                _Synergy2.SetActive(true);
                Synergy1.sprite = Synergys[4];
                SynergyText1.text = "�ż�";
                Synergy2.sprite = Synergys[5];
                SynergyText2.text = "���";
                PlayerPrefs.SetInt("Character", 4);
                break;
            case 6:
                name.text = "�θ�\n";
                unitInfo.text = "���ݷ� 40\n'" +
                    "�ֹ��� 0\n" +
                    "���ݼӵ� 1\n" +
                    "��ų: ���̾� ��\n";
                classLogo.sprite = classLogos[2];
                _Synergy2.SetActive(false);
                Synergy1.sprite = Synergys[2];
                SynergyText1.text = "Ȳȥ";
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
