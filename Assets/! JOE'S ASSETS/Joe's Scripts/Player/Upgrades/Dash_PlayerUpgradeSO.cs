using PLAYERTWO.PlatformerProject;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash_PlayerUpgrade", menuName = "PLAYER TWO/Platformer Project/Player/Upgrades/Dash Player Upgrade")]
public class Dash_PlayerUpgradeSO : Base_PlayerUpgradeSO
{
    [Header("Dash Specific")]
    public float dashDurationIncrease = 0.6f;
    public float dashForceIncrease = 7;

    protected override void Final_ApplyUpgrade(PlayerStats stats)
    {
        stats.dashDuration += dashDurationIncrease;
        stats.dashForce += dashForceIncrease;
    }
}