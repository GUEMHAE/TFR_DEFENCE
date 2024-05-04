using UnityEngine;

public class BagArtifact : MonoBehaviour
{
    // ���� Ŭ����
    [System.Serializable]
    public class Artifact
    {
        public string name;
        public string effect;
    }

    // ���� ���
    public Artifact[] artifacts;

    // ���� ���õ� ����
    private Artifact currentArtifact;

    // ���� ���ΰ�ħ �Լ�
    public void RefreshArtifact()
    {
        int randomIndex = Random.Range(0, artifacts.Length);
        currentArtifact = artifacts[randomIndex];
        Debug.Log("���ο� ������ �߰��߽��ϴ�: " + currentArtifact.name + " - " + currentArtifact.effect);
    }

    // ���� ���õ� ���� ���� ��������
    public string GetCurrentArtifactInfo()
    {
        if (currentArtifact != null)
        {
            return currentArtifact.name + " - " + currentArtifact.effect;
        }
        else
        {
            return "���� ������ �����ϴ�.";
        }
    }
}
