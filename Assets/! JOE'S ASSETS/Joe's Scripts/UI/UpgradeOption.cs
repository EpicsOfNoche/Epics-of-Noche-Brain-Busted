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

    [Space]
    public Button buy_Button;
    public string canBuyText = "Buy";
    public string cannotBuyText = "Already Bought";

    private UpgradeMenu m_upgradeMenu;

    private void Awake()
    {
        Setup();
    }

    private void OnDestroy()
    {
        buy_Button.onClick.RemoveListener(Buy);
        PlayerStatsManager.OnUpgradeBought -= RefreshBuy;
    }

    private void Setup()
    {
        m_upgradeMenu = GetComponentInParent<UpgradeMenu>();

        name_Text.text = playerUpgradeSO.upgradeName;
        description_Text.text = playerUpgradeSO.upgradeDescription;
        cost_Text.text = $"${playerUpgradeSO.upgradeCost.ToString()}";

        upgrade_Image.sprite = playerUpgradeSO.upgradeIcon;

        PlayerStatsManager.OnUpgradeBought += RefreshBuy;
        buy_Button.onClick.AddListener(Buy);

        RefreshBuy(playerUpgradeSO);
    }

    private void Buy()
    {
        PlayerStatsManager.instance.BuyUpgrade(playerUpgradeSO);
    }

    private void RefreshBuy(Base_PlayerUpgradeSO upgradeSO)
    {
        var tmp_Text = buy_Button.GetComponentInChildren<TMP_Text>();
        tmp_Text.text = !PlayerStatsManager.instance.WasBoughtAlready(playerUpgradeSO) ? canBuyText : cannotBuyText;
    }
}