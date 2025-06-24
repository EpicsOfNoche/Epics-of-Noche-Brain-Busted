using System;
using System.Linq;
using UnityEngine;

namespace PLAYERTWO.PlatformerProject
{
	[AddComponentMenu("PLAYER TWO/Platformer Project/Player/Player Stats Manager")]
	public class PlayerStatsManager : EntityStatsManager<PlayerStats>
	{
        protected override void Start()
        {
			base.Start();
			Upgrade();

            UpgradeMenu.OnUpgradeBought += Upgrade;
        }

		private void Upgrade()
		{
            PlayerStats playerStats = Instantiate(original);
			UpgradeStats(playerStats);

            Change(playerStats);
        }

		private void UpgradeStats(PlayerStats stats)
		{
            var boughtUpgrades = Game.instance.ToData().playerUpgradeStats.boughtUpgrades;

            //First we order the bought upgrades by their enum value
            boughtUpgrades = boughtUpgrades.OrderBy(e => (int)e).Distinct().ToList();

            foreach (EPlayerUpgrade upgrade in boughtUpgrades) UpgradeStat(stats, upgrade);
        }

        private void UpgradeStat(PlayerStats stats, EPlayerUpgrade upgrade)
        {
            if (upgrade == EPlayerUpgrade.MaxHealth1) stats.maxHealth += 1;
            else if (upgrade == EPlayerUpgrade.MaxHealth2) stats.maxHealth += 1;
            else if (upgrade == EPlayerUpgrade.MaxHealth3) stats.maxHealth += 1;
            else if (upgrade == EPlayerUpgrade.FasterRunning)
            {
                stats.runningAcceleration += 5f;
                stats.runningTopSpeed += 3f;
            }
            else if (upgrade == EPlayerUpgrade.TripleJump) stats.multiJumps = 3;
            else if (upgrade == EPlayerUpgrade.FurtherDash)
            {
                stats.dashDuration += 0.3f;
                stats.dashForce += 8f;
            }
            else if (upgrade == EPlayerUpgrade.SecondAirDash) stats.allowedAirDashes = 2;
            else if(upgrade == EPlayerUpgrade.HigherAirSpin) stats.airSpinUpwardForce += 5f;
            else if(upgrade == EPlayerUpgrade.BetterGlider)
            {
                stats.glidingMaxFallSpeed -= 0.5f;
                stats.airAcceleration += 0.5f;
            }
        }
    }
}
