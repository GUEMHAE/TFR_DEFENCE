using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_IMG : MonoBehaviour
{
    public float maxSize = 1.2f; // 이미지의 최대 크기
    public float duration = 0.5f; // 애니메이션의 총 시간

    private Vector3 initialScale; // 이미지의 초기 크기
    private bool isGrowing = true; // 커지고 있는지 확인

    void Start()
    {
        initialScale = transform.localScale; // 이미지의 초기 크기를 저장
        StartCoroutine(AnimateLoop()); // 애니메이션 루프 시작
    }

    public void StartAnimation()
    {
        StartCoroutine(AnimateLoop()); // 애니메이션 루프 시작
    }

    IEnumerator AnimateLoop()
    {
        while (true)
        {
            yield return StartCoroutine(AnimateScale(isGrowing)); // 크기 변환 코루틴 실행
            isGrowing = !isGrowing; // 성장 상태 반전
        }
    }

    IEnumerator AnimateScale(bool grow)
    {
        Vector3 targetScale = grow ? initialScale * maxSize : initialScale; // 목표 크기 정하기 grow가 true면 쵀대 크기로 설정 아니면 초기 크기 유지
        Vector3 originalScale = transform.localScale; // 현재 이미지의 크기 저장
        float currentTime = 0.0f;

        while (currentTime < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / duration); //시간에 따라 부드럽게 크기 변경
            currentTime += Time.deltaTime;
            yield return null; // 한 프레임마다 애니메이션 업데이트, 다음 프레임까지 대기
        }

        transform.localScale = targetScale; //애니메이션이 끝난 후 이미지 크기를 목표 크기로 설정
    }
}
