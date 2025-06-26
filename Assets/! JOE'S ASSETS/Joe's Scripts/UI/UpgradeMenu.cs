using PLAYERTWO.PlatformerProject;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeMenu : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 targetPosition;

    private Vector2 showPosition;
    private Vector2 hidePosition;

    private bool showing;

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

    public void ToggleMenu()
    {
        if (showing) Hide();
        else Show();

        rectTransform.anchoredPosition = targetPosition;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GetComponentsInChildren<UpgradeOption>()[0].buy_Button.gameObject);

        showing = true;
        targetPosition = showPosition;
    }
    public void Hide()
    {
        gameObject.SetActive(false);

        showing = false;
        targetPosition = hidePosition;
    }
}