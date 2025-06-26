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

        public static event Action<Base_PlayerUpgradeSO> OnUpgradeBought;

        protected override void Awake()
        {
            base.Awake();
            instance = this;
        }

        protected virtual void Start()
        {
			UpdatePlayerStats();
        }

        public bool BuyUpgrade(Base_PlayerUpgradeSO playerUpgradeSO)
        {
            var boughtUpgrades = m_game.ToData().playerUpgradeStats.boughtUpgrades;
            if (!WasBoughtAlready(playerUpgradeSO) && m_game.ToData().totalCoins >= playerUpgradeSO.upgradeCost)
            {
                //Remove coins from the total coins
                m_game.RemoveFromTotalCoins(playerUpgradeSO.upgradeCost);

                //Add the upgrade to save file and update the stats
                boughtUpgrades.Add(playerUpgradeSO.upgradeID);
                UpdatePlayerStats();

                Debug.Log($"Bought upgrade: {playerUpgradeSO.upgradeName}");
                OnUpgradeBought?.Invoke(playerUpgradeSO);
                return true;
            }

            Debug.Log($"Buying upgrade failed: {playerUpgradeSO.upgradeName}");
            return false;
        }

        public bool WasBoughtAlready(Base_PlayerUpgradeSO playerUpgradeSO)
        {
            return m_game.ToData().playerUpgradeStats.boughtUpgrades.Contains(playerUpgradeSO.upgradeID);
        }

        private void UpdatePlayerStats()
		{
            PlayerStats playerStats = Instantiate(original);
			UpgradeStats(playerStats);

            Change(playerStats);
        }

		private void UpgradeStats(PlayerStats stats)
		{
            var boughtUpgrades = m_game.ToData().playerUpgradeStats.boughtUpgrades;

            //For each bought upgrade, apply the upgrade to the stats
            Resources.LoadAll<Base_PlayerUpgradeSO>("Player Upgrades").Where(upgrade => boughtUpgrades.Contains(upgrade.upgradeID))
                .ToList().ForEach(upgrade => upgrade.ApplyUpgrade(stats));
        }
    }
}
