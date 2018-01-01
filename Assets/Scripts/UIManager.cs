using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Fade the specified image's alpha to the targetAlpha over duration,
    /// and optionally call back via OnComplete.
    /// </summary>
    /// <param name="img">Image.</param>
    /// <param name="targetAlpha">Target alpha.</param>
    /// <param name="duration">Duration.</param>
    /// <param name="OnComplete (optional)">On complete.</param>
    public virtual   IEnumerator Fade(Image img, float targetAlpha, float duration, Action OnComplete = null)
    {
        var elapsed = 0f;
        var startColor = img.color;
        var targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

        while (elapsed < duration)
        {
            img.color = Color.Lerp(startColor, targetColor, (elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (OnComplete != null)
            OnComplete();
    }

    /// <summary>
    /// Fade the specified canvasGroup's alpha to the targetAlpha over duration,
    /// and optionally call back via OnComplete.
    /// </summary>
    /// <param name="canvasGroup">Canvas group.</param>
    /// <param name="targetAlpha">Target alpha.</param>
    /// <param name="duration">Duration.</param>
    /// <param name="OnComplete (optional)">On complete.</param>
    public virtual   IEnumerator Fade(CanvasGroup canvasGroup, float targetAlpha, float duration, Action OnComplete = null)
    {
        var elapsed = 0f;
        var startAlpha = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, (elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (OnComplete != null)
            OnComplete();
    }

    /// <summary>
    /// Scale the specified transform to targetScale over duration,
    /// and optionally call back via OnComplete.
    /// </summary>
    /// <param name="t">T.</param>
    /// <param name="targetScale">Target scale.</param>
    /// <param name="duration">Duration.</param>
    /// <param name="OnComplete (optional)">On complete.</param>
    public virtual  IEnumerator Scale(Transform t, Vector3 targetScale, float duration, Action OnComplete = null)
    {
        var elapsed = 0f;
        var startScale = t.localScale;

        while (elapsed < duration)
        {
            t.localScale = Vector3.Lerp(startScale, targetScale, (elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (OnComplete != null)
            OnComplete();
    }

    /// <summary>
    /// Moves the anchor position of the specified rectTransform's X value to targetPosX over duration,
    /// and optionally calls back via OnComplete.
    /// </summary>
    /// <returns>The anchor position.</returns>
    /// <param name="t">T.</param>
    /// <param name="targetPos">Target position.</param>
    /// <param name="duration">Duration.</param>
    /// <param name="OnComplete (optional)">On complete.</param>
    public virtual IEnumerator MoveAnchorPositionX(RectTransform t, float targetPosX, float duration, Action OnComplete = null)
    {
        var elapsed = 0f;
        var startPos = t.anchoredPosition;
        var targetPos = new Vector2(targetPosX, t.anchoredPosition.y);

        while (elapsed < duration)
        {
            t.anchoredPosition = Vector2.Lerp(startPos, targetPos, (elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (OnComplete != null)
            OnComplete();
    }
}
