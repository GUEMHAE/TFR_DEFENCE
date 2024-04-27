using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP : MonoBehaviour
{
    public GameObject imagePrefab; // 생성할 이미지 프리팹
    public Transform spawnPoint; // 이미지가 생성될 위치
    public float fadeInDuration = 2.0f; // 페이드 인 지속 시간
    public AnimationCurve fadeInCurve; // 페이드 인 곡선
    public float rotationAngle = 0.0f; // 이미지의 초기 z축 회전 각도

    private GameObject instantiatedImage; // 생성된 이미지 오브젝트
    private float startTime; // 애니메이션 시작 시간

    void Start()
    {
        // 애니메이션 초기화
        RestartAnimation();
    }

    void Update()
    {
        // 경과 시간 계산
        float elapsedTime = Time.time - startTime;

        // 페이드 인 애니메이션 적용
        float alpha = fadeInCurve.Evaluate(elapsedTime / fadeInDuration); // 경과 시간에 따른 투명도 계산
        SpriteRenderer spriteRenderer = instantiatedImage.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, alpha); // 이미지의 투명도 설정

        // 애니메이션 종료 후 재시작
        if (elapsedTime >= fadeInDuration)
        {
            RestartAnimation();
        }
    }

    // 애니메이션 재시작 함수
    void RestartAnimation()
    {
        startTime = Time.time; // 애니메이션 시작 시간 설정

        // 이미지 생성
        if (instantiatedImage != null)
        {
            Destroy(instantiatedImage); // 기존 이미지 제거
        }
        instantiatedImage = Instantiate(imagePrefab, spawnPoint.position, Quaternion.identity);
        SpriteRenderer spriteRenderer = instantiatedImage.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f); // 처음에는 투명도를 0으로 설정

        // 이미지 초기 회전 각도 설정
        instantiatedImage.transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
