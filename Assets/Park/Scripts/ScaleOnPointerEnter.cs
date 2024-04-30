using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ScaleOnPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 0.3f;
    public float duration = 0.3f;

    private Vector3 originalScale;
    private Tweener scaleTween;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Round.instance.isRound == false)
        {
            if (scaleTween != null && scaleTween.IsPlaying())
            {
                scaleTween.Kill(); // 기존 애니메이션이 실행 중이라면 중지
            }
            scaleTween = transform.DOScale(originalScale * (1 + scaleFactor), duration);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Round.instance.isRound == false)
        {
            if (scaleTween != null && scaleTween.IsPlaying())
            {
                scaleTween.Kill(); // 기존 애니메이션이 실행 중이라면 중지
            }
            scaleTween = transform.DOScale(originalScale, duration);
        }
    }
}
