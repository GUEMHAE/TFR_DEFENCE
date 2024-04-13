using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSprite_Unit : MonoBehaviour
{
    public Image[] imageSlots; // 4���� �̹��� ����
    public Sprite[] sprites; // 16���� ��������Ʈ�� ������ �迭

    void Start()
    {
        RandomSprite();
    }


    public void RandomSprite()
    {
        // ��������Ʈ�� ������ ����Ʈ ����
        List<Sprite> selectedSprites = new List<Sprite>();

        // �迭���� 4���� ��������Ʈ�� �������� �����Ͽ� ����Ʈ�� �߰�
        for (int i = 0; i < 4; i++)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            selectedSprites.Add(sprites[randomIndex]);
        }

        // ���õ� ��������Ʈ�� �� �̹����� ǥ��
        for (int i = 0; i < selectedSprites.Count; i++)
        {
            imageSlots[i].sprite = selectedSprites[i];
        }
    }
}
