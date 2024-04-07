using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exp : MonoBehaviour
{
    public TMP_Text levelText; // ������ ǥ���� �ؽ�Ʈ UI

    public int exp;  // ����ġ�� �����ϴ� ����
    private int level = 0;       // ���� ������ �����ϴ� ����

    void Update()
    {
        exp = Round.instance.exp;

        // ���� �ؽ�Ʈ ������Ʈ
        levelText.text = "Level: " + level.ToString();


        // ����ġ�� ���� ���� �̻��� ��� ���� ��
        if (exp >= Levelup(level))
        {
            if (level < 6)
            {
                Round.instance.exp -= Levelup(level);
                level++;
            }
            else
                Round.instance.exp = 0;
        }

    }

    // ����ġ ���� �Լ�
    public void IncreaseExperience()
    {
            exp += 3;
    }

    // �������� �ʿ��� ����ġ �� ��ȯ �Լ�
    public int Levelup(int currentLevel)
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
