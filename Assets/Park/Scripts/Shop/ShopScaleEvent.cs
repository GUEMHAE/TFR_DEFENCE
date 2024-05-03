using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopScaleEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 0.1f;
    public float duration = 0.2f;

    private Vector3 originalScale;
    private Tweener scaleTween;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

            if (scaleTween != null && scaleTween.IsPlaying())
            {
                scaleTween.Kill();
            }
            scaleTween = transform.DOScale(originalScale * (1 + scaleFactor), duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            if (scaleTween != null && scaleTween.IsPlaying())
            {
                scaleTween.Kill();
            }
            scaleTween = transform.DOScale(originalScale, 0);
    }
}
