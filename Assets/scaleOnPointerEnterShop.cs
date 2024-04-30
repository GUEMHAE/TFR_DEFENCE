using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scaleOnPointerEnterShop : MonoBehaviour
{
    public float scaleFactor = 0.2f;
    public float duration = 0.2f;

    private Vector3 originalScale;
    private Tweener scaleTween;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    public void ScaleUp()
    {
        if( spriteRenderer.sprite != null)
            if (scaleTween != null && scaleTween.IsPlaying())
            {
                scaleTween.Kill(); // 기존 애니메이션이 실행 중이라면 중지
            }
            scaleTween = transform.DOScale(originalScale * (1 + scaleFactor), duration);
    }

    public void ScaleDown()
    {
            if (scaleTween != null && scaleTween.IsPlaying())
            {
                scaleTween.Kill(); // 기존 애니메이션이 실행 중이라면 중지
            }
            scaleTween = transform.DOScale(originalScale, 0);
    }
}
