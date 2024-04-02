using UnityEngine;
using UnityEngine.UI;

public class RandomUnitSelector : MonoBehaviour
{
    public DisplaySelectedUnit displayUnitScript; // DisplaySelectedUnit ��ũ��Ʈ ����
    public UnitData[] unitPool; // �������� ������ ���ֵ��� �迭

    // �����ϰ� ������ �����Ͽ� �ش� �̹����� ǥ���ϴ� �Լ�
    public void SelectRandomUnitAndDisplayImage()
    {
        // ���� Ǯ���� �����ϰ� ���� ����
        UnitData randomUnit = unitPool[Random.Range(0, unitPool.Length)];

        // ���õ� ������ �̹����� DisplaySelectedUnit ��ũ��Ʈ�� ���� ǥ��
        displayUnitScript.DisplayRandomUnitImage(randomUnit.unitImage);
    }
}
