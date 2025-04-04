using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LearnPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private void OnEnable()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(transform.DOScale(Vector2.one, 0.5f).From(0).SetEase(Ease.OutBack))
            .Join(canvasGroup.DOFade(1,0.5f));
    }
    public void ClosePanel()
    {
        StartCoroutine(ClosedPanel());
    }
    private IEnumerator ClosedPanel()
    {
        yield return canvasGroup.DOFade(0, 0.5f).WaitForCompletion();

        gameObject.SetActive(false);
    }
}
