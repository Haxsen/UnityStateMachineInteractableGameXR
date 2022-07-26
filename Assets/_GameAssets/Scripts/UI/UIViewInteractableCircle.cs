using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the world UI for the interactable.
/// </summary>
public class UIViewInteractableCircle : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] Image outerCircleImageComponent;
    [SerializeField] float outerCircleSizeDecrement = 0.1f;
    [SerializeField] float outerCircleAlphaMax = 0.7f;
    
    [SerializeField] Image fillableCircleImageComponent;

    // private variables
    private float outerCircleSize;

    private Coroutine _outerCircleCoroutine;
    private Huntable _huntable;

    #region MonoBehaviour
    private void Awake()
    {
        _huntable = GetComponentInParent<Huntable>();
        
        outerCircleSize = outerCircleImageComponent.rectTransform.rect.width;
    }
    #endregion

    /// <summary>
    /// Starts the interaction by resetting the objects first.
    /// </summary>
    public void StartInteraction()
    {
        // reset outer circle
        outerCircleImageComponent.gameObject.SetActive(true);
        outerCircleImageComponent.rectTransform.sizeDelta = new Vector2(outerCircleSize, outerCircleSize);
        SetOuterCircleColorAlpha(outerCircleAlphaMax);
        
        // reset the fillable circle
        fillableCircleImageComponent.gameObject.SetActive(true);
        fillableCircleImageComponent.fillAmount = 0;
    }

    /// <summary>
    /// Progresses the interaction circles.
    /// </summary>
    public void FillCircle()
    {
        float holdTime = _huntable.GetHoldTime();
        fillableCircleImageComponent.fillAmount = holdTime;
        SetOuterCircleColorAlpha(outerCircleAlphaMax - holdTime);
        DecreaseOuterCircleSize(outerCircleSizeDecrement);
    }

    /// <summary>
    /// Sets the outer circle's alpha.
    /// </summary>
    /// <param name="newAlphavalue">the new value for alpha</param>
    private void SetOuterCircleColorAlpha(float newAlphavalue)
    {
        var color = outerCircleImageComponent.color;
        color.a = newAlphavalue;
        outerCircleImageComponent.color = color;
    }

    /// <summary>
    /// Decreases the outer circle's size by value.
    /// </summary>
    /// <param name="sizeDecrement">the decrement in size</param>
    private void DecreaseOuterCircleSize(float sizeDecrement)
    {
        outerCircleImageComponent.rectTransform.sizeDelta -= new Vector2(sizeDecrement, sizeDecrement);
    }
}
