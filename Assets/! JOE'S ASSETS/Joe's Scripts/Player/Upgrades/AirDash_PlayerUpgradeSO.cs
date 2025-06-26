using PLAYERTWO.PlatformerProject;
using UnityEngine;

[CreateAssetMenu(fileName = "AirDash_PlayerUpgrade", menuName = "PLAYER TWO/Platformer Project/Player/Air Dash Player Upgrade")]
public class AirDash_PlayerUpgradeSO : Base_PlayerUpgradeSO
{
    [Header("Air Dash Specific")]
    public int allowedAirDashesIncrease = 1;

    protected override void Final_ApplyUpgrade(PlayerStats stats)
    {
        stats.allowedAirDashes += allowedAirDashesIncrease;
    }
}