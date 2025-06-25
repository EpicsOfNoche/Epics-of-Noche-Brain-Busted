using PLAYERTWO.PlatformerProject;
using System;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public static event Action OnUpgradeBought;

    private RectTransform rectTransform;

    private Vector2 showPosition;
    private Vector2 hidePosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        showPosition = rectTransform.anchoredPosition;
        hidePosition = new Vector2(-rectTransform.sizeDelta.x, rectTransform.anchoredPosition.y);

        rectTransform.anchoredPosition = hidePosition;
    }

    private void Update()
    {
        
    }

    public void Show()
    {
        rectTransform.anchoredPosition = showPosition;
    }
    public void Hide()
    {
        rectTransform.anchoredPosition = hidePosition;
    }
}