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
        levelText.text = level.ToString();
        exping.text = exp.ToString() + " / " + expBar.ToString();
        UnitLimitManager.instance.MaxunitCount = 1;
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
                levelText.text = level.ToString();
                exping.text = exp.ToString() + " / " + expBar.ToString();
            }

            else
            {
                exp = 0; // �ִ� �������� ���� ����ġ 0���� �ʱ�ȭ // �� �̻� ���� ����
                levelText.text = "MAX";
                exping.enabled = false;
            }
        }

    }

    // ��ư Ŭ�� ����ġ ���� �Լ�
    public void IncreaseExperience()
    {
        if (GameManager.instance.gold >= 3&&level!=6)
        {
            exp += 3;
            GameManager.instance.gold -= 3;
            ExpBarSlider.value = exp / expBar;

            levelText.text = level.ToString();
            exping.text = exp.ToString() + " / " + expBar.ToString();
        }
    }

    // �������� �ʿ��� ����ġ �� ��ȯ �Լ�
    public float Levelup(float currentLevel)
    {
        //Debug.Log(UnitLimitManager.instance.MaxunitCount);
        // �� �������� �ʿ��� ����ġ �� ����
        switch (currentLevel)
        {
            case 1:
                UnitLimitManager.instance.MaxunitCount = 2;
                return 2;
            case 2:
                UnitLimitManager.instance.MaxunitCount = 3;
                return 6;
            case 3:
                UnitLimitManager.instance.MaxunitCount = 4;
                return 12;
            case 4:
                UnitLimitManager.instance.MaxunitCount = 5;
                return 24;
            case 5:
                UnitLimitManager.instance.MaxunitCount = 6;
                return 48;
            case 6:
                UnitLimitManager.instance.MaxunitCount = 7;
                return 0;
        }
        return exp;
    }
}
