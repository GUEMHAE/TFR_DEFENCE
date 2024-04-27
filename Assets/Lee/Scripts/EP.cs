using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP : MonoBehaviour
{
    public GameObject imagePrefab; // ������ �̹��� ������
    public Transform spawnPoint; // �̹����� ������ ��ġ
    public float fadeInDuration = 2.0f; // ���̵� �� ���� �ð�
    public AnimationCurve fadeInCurve; // ���̵� �� �
    public float rotationAngle = 0.0f; // �̹����� �ʱ� z�� ȸ�� ����

    private GameObject instantiatedImage; // ������ �̹��� ������Ʈ
    private float startTime; // �ִϸ��̼� ���� �ð�

    void Start()
    {
        // �ִϸ��̼� �ʱ�ȭ
        RestartAnimation();
    }

    void Update()
    {
        // ��� �ð� ���
        float elapsedTime = Time.time - startTime;

        // ���̵� �� �ִϸ��̼� ����
        float alpha = fadeInCurve.Evaluate(elapsedTime / fadeInDuration); // ��� �ð��� ���� ���� ���
        SpriteRenderer spriteRenderer = instantiatedImage.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, alpha); // �̹����� ���� ����

        // �ִϸ��̼� ���� �� �����
        if (elapsedTime >= fadeInDuration)
        {
            RestartAnimation();
        }
    }

    // �ִϸ��̼� ����� �Լ�
    void RestartAnimation()
    {
        startTime = Time.time; // �ִϸ��̼� ���� �ð� ����

        // �̹��� ����
        if (instantiatedImage != null)
        {
            Destroy(instantiatedImage); // ���� �̹��� ����
        }
        instantiatedImage = Instantiate(imagePrefab, spawnPoint.position, Quaternion.identity);
        SpriteRenderer spriteRenderer = instantiatedImage.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f); // ó������ ������ 0���� ����

        // �̹��� �ʱ� ȸ�� ���� ����
        instantiatedImage.transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
