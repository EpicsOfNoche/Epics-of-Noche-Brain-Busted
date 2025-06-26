using PLAYERTWO.PlatformerProject;
using System;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public static event Action<Base_PlayerUpgradeSO> OnUpgradeBought;

    private RectTransform rectTransform;

    private Vector2 showPosition;
    private Vector2 hidePosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        showPosition = rectTransform.anchoredPosition;
        hidePosition = new Vector2(-rectTransform.sizeDelta.x, rectTransform.anchoredPosition.y);

        rectTransform.anchoredPosition = hidePosition;

        LevelPauser.instance.OnUnpause.AddListener(Hide);
    }

    private void OnDestroy()
    {
        LevelPauser.instance.OnUnpause.RemoveListener(Hide);
    }

    public bool BuyUpgrade(Base_PlayerUpgradeSO upgradeSO)
    {
        if (PlayerStatsManager.instance.BuyUpgrade(upgradeSO))
        {
            Debug.Log($"Bought upgrade: {upgradeSO.upgradeName}");

            OnUpgradeBought?.Invoke(upgradeSO);
            return true;
        }
        else
        {
            Debug.Log($"Buying upgrade failed: {upgradeSO.upgradeName}");
            return false;
        }
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