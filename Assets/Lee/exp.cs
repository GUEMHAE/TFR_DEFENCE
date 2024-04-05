using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exp : MonoBehaviour
{
    public TMP_Text expText;   // ����ġ�� ǥ���� �ؽ�Ʈ UI
    public TMP_Text levelText; // ������ ǥ���� �ؽ�Ʈ UI

    private float interval = 60f; // ����ġ�� �����ϴ� ���� (�� ����)
    private int round = 1;       // ���� ���带 �����ϴ� ����
    private int exp = 0;  // ����ġ�� �����ϴ� ����
    private int level = 0;       // ���� ������ �����ϴ� ����

    void Start()
    {
        //expText = Round.instance.expText;
        //exp = Round.instance.exp;
    }

    void Update()
    {
        // ����ġ �ؽ�Ʈ ������Ʈ
       // expText.text = "Experience: " + experience.ToString();

        // ���� �ؽ�Ʈ ������Ʈ
        levelText.text = "Level: " + level.ToString();


        // ����ġ�� ���� ���� �̻��� ��� ���� ��
        if (exp >= GetExperienceRequiredForLevelUp(level))
        {
            if (level < 6)
            {
                level++;
                exp = 0; // ����ġ �ʱ�ȭ
            }
            exp = 0;
        }
    }

    // ����ġ ���� �Լ�
    public void IncreaseExperience()
    {
        exp += 3;

        expText.text = "Exp: " + exp.ToString();
    }

    // �������� �ʿ��� ����ġ �� ��ȯ �Լ�
    public int GetExperienceRequiredForLevelUp(int currentLevel)
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
