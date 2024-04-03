using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exe : MonoBehaviour
{
    public Text timerText; // �ð��� ǥ���� �ؽ�Ʈ UI
    public Text roundText; // ���带 ǥ���� �ؽ�Ʈ UI
    public Text expText;   // ����ġ�� ǥ���� �ؽ�Ʈ UI
    public Text levelText; // ������ ǥ���� �ؽ�Ʈ UI
    public Button expButton; // ����ġ�� ������ų ��ư

    private float timer = 0f;    // ��� �ð��� �����ϴ� Ÿ�̸� ����
    private float interval = 60f; // ����ġ�� �����ϴ� ���� (�� ����)
    private int round = 1;       // ���� ���带 �����ϴ� ����
    private int experience = 0;  // ����ġ�� �����ϴ� ����
    private int level = 0;       // ���� ������ �����ϴ� ����

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ ����
        expButton.onClick.AddListener(IncreaseExperience);
    }

    void Update()
    {
        // ��� �ð� ������Ʈ
        timer += Time.deltaTime;

        // ��� �ð� �ؽ�Ʈ ������Ʈ
        timerText.text = "Time: " + Mathf.FloorToInt(timer).ToString() + "s";

        // ���� �ؽ�Ʈ ������Ʈ
        roundText.text = "Round: " + round.ToString();

        // ����ġ �ؽ�Ʈ ������Ʈ
        expText.text = "Experience: " + experience.ToString();

        // ���� �ؽ�Ʈ ������Ʈ
        levelText.text = "Level: " + level.ToString();

        // ����ġ�� ���� ���� �̻��� ��� ���� ��
        if (experience >= GetExperienceRequiredForLevelUp(level))
        {
            level++;
            experience = 0; // ����ġ �ʱ�ȭ
        }
    }

    // ����ġ ���� �Լ�
    void IncreaseExperience()
    {
        experience += 3;
    }

    // �������� �ʿ��� ����ġ �� ��ȯ �Լ�
    int GetExperienceRequiredForLevelUp(int currentLevel)
    {
        // �� �������� �ʿ��� ����ġ �� ����
        switch (currentLevel)
        {
            case 0: return 2;
            case 1: return 6;
            case 2: return 12;
            case 3: return 18;
            case 4: return 28;
            default: return int.MaxValue; // �ִ밪���� �����Ͽ� ���� ������ ������ �ǹ�
        }
    }
}
