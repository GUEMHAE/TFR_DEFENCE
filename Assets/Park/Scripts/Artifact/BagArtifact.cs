using UnityEngine;

public class BagArtifact : MonoBehaviour
{
    // 유물 클래스
    [System.Serializable]
    public class Artifact
    {
        public string name;
        public string effect;
    }

    // 유물 목록
    public Artifact[] artifacts;

    // 현재 선택된 유물
    private Artifact currentArtifact;

    // 유물 새로고침 함수
    public void RefreshArtifact()
    {
        int randomIndex = Random.Range(0, artifacts.Length);
        currentArtifact = artifacts[randomIndex];
        Debug.Log("새로운 유물을 발견했습니다: " + currentArtifact.name + " - " + currentArtifact.effect);
    }

    // 현재 선택된 유물 정보 가져오기
    public string GetCurrentArtifactInfo()
    {
        if (currentArtifact != null)
        {
            return currentArtifact.name + " - " + currentArtifact.effect;
        }
        else
        {
            return "현재 유물이 없습니다.";
        }
    }
}
