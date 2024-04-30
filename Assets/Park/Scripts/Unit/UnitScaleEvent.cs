using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitScaleEvent :MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
                scaleTween.Kill();
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
                scaleTween.Kill();
            }
            scaleTween = transform.DOScale(originalScale, duration);
        }
    }
}
