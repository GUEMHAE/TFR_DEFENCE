using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exp : MonoBehaviour
{
    public TMP_Text levelText; // ������ ǥ���� �ؽ�Ʈ UI

    public float exp;  // ����ġ�� �����ϴ� ����
    private float level = 0;  // ���� ������ �����ϴ� ����
    public float expBar; // �������� �ʿ��� ����ġ
    public Slider ExpBarSlider; // ����ġ �����̴�
    public TMP_Text exping; // ���� ����ġ / �������� �ʿ��� ����ġ

    void Start()
    {
        ExpBarSlider.value = (float)exp / (float)expBar; // Exp�� ���� ���� ����ġ / �������� �ʿ��� ����ġ�� ����
    }


    void Update()
    {
        exp = Round.instance.exp; // Round ��ũ��Ʈ�� �ִ� exp�� ����
        expBar = Levelup(level); // ���� �� �� ������ �ʿ��� ����ġ ���� ����

        exping.text = exp.ToString() + " / " + expBar.ToString();

        // ���� �ؽ�Ʈ ������Ʈ
        levelText.text = "Level: " + level.ToString();


        // ����ġ�� ���� ���� �̻��� ��� ���� ��
        if (exp >= Levelup(level))
        {
            if (level < 6) //6���� ���� �ݺ�
            {
                Round.instance.exp -= Levelup(level); // �ʿ��� ����ġ�� �� ����ġ���� ��
                level++; // ���� ��
            }
            else
                Round.instance.exp = 0; // �ִ� �������� ���� ����ġ 0���� �ʱ�ȭ // �� �̻� ���� ����
        }
    }



    // ��ư Ŭ�� ����ġ ���� �Լ�
    public void IncreaseExperience()
    {
        Round.instance.exp += 3;
        CheckExp();
    }

    public void CheckExp()
    {
            ExpBarSlider.value = (float)exp / (float)expBar;
    }

    // �������� �ʿ��� ����ġ �� ��ȯ �Լ�
    public float Levelup(float currentLevel)
    {
        // �� �������� �ʿ��� ����ġ �� ����
        switch (currentLevel)
        {
            case 1: return 2;
            case 2: return 6;
            case 3: return 12;
            case 4: return 18;
            case 5: return 28;
            case 6: return 0;
        }
        return exp;
    }
}
