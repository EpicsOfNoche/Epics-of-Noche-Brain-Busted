using PLAYERTWO.PlatformerProject;
using UnityEngine;

[CreateAssetMenu(fileName = "AirSpin_PlayerUpgrade", menuName = "PLAYER TWO/Platformer Project/Player/Upgrades/Air Spin Player Upgrade")]
public class AirSpin_PlayerUpgradeSO : Base_PlayerUpgradeSO
{
    [Header("Air Spin Specific")]
    public float airSpinUpwardForceIncrease = 5;
    public int maxAirSpinsIncrease = 1;

    protected override void Final_ApplyUpgrade(PlayerStats stats)
    {
        stats.airSpinUpwardForce += airSpinUpwardForceIncrease;
        stats.allowedAirSpins += maxAirSpinsIncrease;
    }
}