using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_IMG : MonoBehaviour
{
    public float maxSize = 1.2f; // �̹����� �ִ� ũ��
    public float duration = 0.5f; // �ִϸ��̼��� �� �ð�

    private Vector3 initialScale; // �̹����� �ʱ� ũ��
    private bool isGrowing = true; // Ŀ���� �ִ��� Ȯ��

    void Start()
    {
        initialScale = transform.localScale; // �̹����� �ʱ� ũ�⸦ ����
        StartCoroutine(AnimateLoop()); // �ִϸ��̼� ���� ����
    }

    public void StartAnimation()
    {
        StartCoroutine(AnimateLoop()); // �ִϸ��̼� ���� ����
    }

    IEnumerator AnimateLoop()
    {
        while (true)
        {
            yield return StartCoroutine(AnimateScale(isGrowing)); // ũ�� ��ȯ �ڷ�ƾ ����
            isGrowing = !isGrowing; // ���� ���� ����
        }
    }

    IEnumerator AnimateScale(bool grow)
    {
        Vector3 targetScale = grow ? initialScale * maxSize : initialScale; // ��ǥ ũ�� ���ϱ� grow�� true�� ���� ũ��� ���� �ƴϸ� �ʱ� ũ�� ����
        Vector3 originalScale = transform.localScale; // ���� �̹����� ũ�� ����
        float currentTime = 0.0f;

        while (currentTime < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / duration); //�ð��� ���� �ε巴�� ũ�� ����
            currentTime += Time.deltaTime;
            yield return null; // �� �����Ӹ��� �ִϸ��̼� ������Ʈ, ���� �����ӱ��� ���
        }

        transform.localScale = targetScale; //�ִϸ��̼��� ���� �� �̹��� ũ�⸦ ��ǥ ũ��� ����
    }
}
