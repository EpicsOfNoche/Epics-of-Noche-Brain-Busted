using PLAYERTWO.PlatformerProject;
using UnityEngine;

[CreateAssetMenu(fileName = "Glider_PlayerUpgrade", menuName = "PLAYER TWO/Platformer Project/Player/Upgrades/Glider Player Upgrade")]
public class Glider_PlayerUpgradeSO : Base_PlayerUpgradeSO
{
    [Header("Glider Specific")]
    [Tooltip("Don't make this a negative number")] public float glideFallSpeedDecrease = 0.5f;
    public float glidingRotationSpeedIncrease = 30;

    protected override void Final_ApplyUpgrade(PlayerStats stats)
    {
        stats.glidingMaxFallSpeed -= glideFallSpeedDecrease;
        stats.glidingRotationSpeed += glidingRotationSpeedIncrease;
    }
}