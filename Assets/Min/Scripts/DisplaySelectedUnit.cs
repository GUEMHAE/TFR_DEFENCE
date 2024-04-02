using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedUnit : MonoBehaviour
{
    public RawImage unitImage; // UI���� �̹����� ǥ���� RawImage ���

    // �����ϰ� ���õ� ������ �̹����� ǥ���ϴ� �Լ�
    public void DisplayRandomUnitImage(Texture2D unitTexture)
    {
        // ���� �̹����� ��ȿ�� ��쿡�� �̹����� ǥ��
        if (unitTexture != null)
        {
            unitImage.texture = unitTexture; // RawImage�� texture �Ӽ��� ���õ� ������ �̹����� ����
            unitImage.enabled = true; // RawImage�� Ȱ��ȭ�Ͽ� �̹����� ǥ��
        }
        else
        {
            Debug.LogError("��ȿ���� ���� ���� �̹����Դϴ�.");
        }
    }
}
