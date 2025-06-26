using PLAYERTWO.PlatformerProject;
using UnityEngine;

[CreateAssetMenu(fileName = "Jumping_PlayerUpgrade", menuName = "PLAYER TWO/Platformer Project/Player/Jumping Player Upgrade")]
public class Jumping_PlayerUpgradeSO : Base_PlayerUpgradeSO
{
    [Header("Jumping Specific")]
    public int maxJumpsIncrease = 1;

    protected override void Final_ApplyUpgrade(PlayerStats stats)
    {
        stats.multiJumps += maxJumpsIncrease;
    }
}