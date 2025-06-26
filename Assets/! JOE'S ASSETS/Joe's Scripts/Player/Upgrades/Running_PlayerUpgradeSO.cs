using PLAYERTWO.PlatformerProject;
using UnityEngine;

[CreateAssetMenu(fileName = "Running_PlayerUpgrade", menuName = "PLAYER TWO/Platformer Project/Player/Upgrades/Running Player Upgrade")]
public class Running_PlayerUpgradeSO : Base_PlayerUpgradeSO
{
    [Header("Running Specific")]
    public float runAccelerationIncrease = 5;
    public float runTopSpeedIncrease = 3;

    protected override void Final_ApplyUpgrade(PlayerStats stats)
    {
        stats.runningAcceleration += runAccelerationIncrease;
        stats.runningTopSpeed += runTopSpeedIncrease;
    }
}