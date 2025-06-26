using PLAYERTWO.PlatformerProject;
using UnityEngine;

public class UpgradeOption : MonoBehaviour
{
    public Base_PlayerUpgradeSO playerUpgradeSO;

    public void Buy()
    {
        GetComponentInParent<UpgradeMenu>().BuyUpgrade(playerUpgradeSO);
    }
}