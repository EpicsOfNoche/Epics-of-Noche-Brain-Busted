using PLAYERTWO.PlatformerProject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeOption : MonoBehaviour
{
    public Base_PlayerUpgradeSO playerUpgradeSO;

    [Header("UI - Information")]
    public TMP_Text name_Text;
    public TMP_Text description_Text;
    public TMP_Text cost_Text;

    [Header("UI - Buying")]
    public Image upgrade_Image;
    public Button buy_Button;

    private void Awake()
    {
        Setup();
    }

    private void OnDestroy()
    {
        buy_Button.onClick.RemoveListener(Buy);
    }

    private void Setup()
    {
        name_Text.text = playerUpgradeSO.upgradeName;
        description_Text.text = playerUpgradeSO.upgradeDescription;
        cost_Text.text = $"${playerUpgradeSO.upgradeCost.ToString()}";

        upgrade_Image.sprite = playerUpgradeSO.upgradeIcon;
        buy_Button.onClick.AddListener(Buy);
    }

    private void Buy()
    {
        GetComponentInParent<UpgradeMenu>().BuyUpgrade(playerUpgradeSO);
    }
}