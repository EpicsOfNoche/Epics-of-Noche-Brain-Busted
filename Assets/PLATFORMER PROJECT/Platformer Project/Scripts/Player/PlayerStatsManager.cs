using System;
using System.Linq;
using UnityEngine;

namespace PLAYERTWO.PlatformerProject
{
	[AddComponentMenu("PLAYER TWO/Platformer Project/Player/Player Stats Manager")]
	public class PlayerStatsManager : EntityStatsManager<PlayerStats>
	{
        public static PlayerStatsManager instance { get; private set; }

        private Game m_game => Game.instance;

        private void Awake()
        {
            instance = this;
        }

        protected override void Start()
        {
			base.Start();
			UpdatePlayerStats();
        }

        public bool BuyUpgrade(Base_PlayerUpgradeSO playerUpgradeSO)
        {
            var boughtUpgrades = m_game.m_playerUpgradeStats.boughtUpgrades;
            if (!boughtUpgrades.Contains(playerUpgradeSO.upgradeID) && m_game.m_totalCoins >= playerUpgradeSO.upgradeCost)
            {
                m_game.m_totalCoins -= playerUpgradeSO.upgradeCost;
                boughtUpgrades.Add(playerUpgradeSO.upgradeID);

                UpdatePlayerStats();

                return true;
            }

            return false;
        }

		private void UpdatePlayerStats()
		{
            PlayerStats playerStats = Instantiate(original);
			UpgradeStats(playerStats);

            Change(playerStats);
        }

		private void UpgradeStats(PlayerStats stats)
		{
            var boughtUpgrades = m_game.m_playerUpgradeStats.boughtUpgrades;

            //For each bought upgrade, apply the upgrade to the stats
            Resources.LoadAll<Base_PlayerUpgradeSO>("Player Upgrades").Where(upgrade => boughtUpgrades.Contains(upgrade.upgradeID))
                .ToList().ForEach(upgrade => upgrade.ApplyUpgrade(stats));
        }
    }
}
