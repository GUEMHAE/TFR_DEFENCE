using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exp : MonoBehaviour
{
    public TMP_Text levelText; // ������ ǥ���� �ؽ�Ʈ UI

    public float exp;  // ����ġ�� �����ϴ� ����
    public int level = 1;  // ���� ������ �����ϴ� ����
    public float expBar; // �������� �ʿ��� ����ġ
    public Slider ExpBarSlider; // ����ġ �����̴�
    public TMP_Text exping; // ���� ����ġ / �������� �ʿ��� ����ġ

    void Start()
    {
        ExpBarSlider.value = 0;// Exp�� ���� ���� ����ġ / �������� �ʿ��� ����ġ�� ����

        // ���� �ؽ�Ʈ ������Ʈ
        levelText.text = "Level: " + level.ToString();
        exping.text = exp.ToString() + " / " + expBar.ToString();
    }


    void Update()
    {
        expBar = Levelup(level); // ���� �� �� ������ �ʿ��� ����ġ ���� ����

        // ����ġ�� ���� ���� �̻��� ��� ���� ��
        if (exp >= Levelup(level))
        {
            if (level < 6) //6���� ���� �ݺ�
            {
                exp -= Levelup(level); // �ʿ��� ����ġ�� �� ����ġ���� ��
                level++; // ���� ��
                levelText.text = "Level: " + level.ToString();
                exping.text = exp.ToString() + " / " + expBar.ToString();
            }

            else
            {
                exp = 0; // �ִ� �������� ���� ����ġ 0���� �ʱ�ȭ // �� �̻� ���� ����
                levelText.text = "MaxLevel";
                exping.enabled = false;
            }
        }

    }



    // ��ư Ŭ�� ����ġ ���� �Լ�
    public void IncreaseExperience()
    {
        exp += 3;
        ExpBarSlider.value = exp / expBar;

        levelText.text = "Level: " + level.ToString();
        exping.text = exp.ToString() + " / " + expBar.ToString();
    }

    // �������� �ʿ��� ����ġ �� ��ȯ �Լ�
    public float Levelup(float currentLevel)
    {
        // �� �������� �ʿ��� ����ġ �� ����
        switch (currentLevel)
        {
            case 1: return 3;
            case 2: return 6;
            case 3: return 12;
            case 4: return 18;
            case 5: return 28;
            case 6: return 0;
        }
        return exp;


    }
}
