using PLAYERTWO.PlatformerProject;
using UnityEngine;

[CreateAssetMenu(fileName = "Health_PlayerUpgrade", menuName = "PLAYER TWO/Platformer Project/Player/Health Player Upgrade")]
public class Health_PlayerUpgradeSO : Base_PlayerUpgradeSO
{
    [Header("Health Specific")]
    public int maxHealthIncrease = 1;

    protected override void Final_ApplyUpgrade(PlayerStats stats)
    {
        stats.maxHealth += maxHealthIncrease;
    }
}