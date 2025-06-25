using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PLAYERTWO.PlatformerProject
{
	[Serializable]
	public class GameData
	{
		public int retries;
		public LevelData[] levels;
		public string createdAt;
		public string updatedAt;

		public int totalCoins;
		public PlayerUpgradeStats playerUpgradeStats;

        /// <summary>
        /// Returns a new instance of Game Data at runtime.
        /// </summary>
        public static GameData Create()
		{
			return new GameData()
			{
				retries = Game.instance.initialRetries,
				createdAt = DateTime.UtcNow.ToString(),
				updatedAt = DateTime.UtcNow.ToString(),
				levels = Game
					.instance.levels.Select(
						(level) =>
						{
							return new LevelData()
							{
								collectedCoins = new List<string>(),
                                locked = level.locked,
								stars = new bool[Game.instance.starsPerLevel],
							};
						}
					)
					.ToArray(),

				totalCoins = 0,
                playerUpgradeStats = new PlayerUpgradeStats(),
            };
		}

        /// <summary>
        /// Returns the sum of Stars collected in all Levels.
        /// </summary>
        public virtual int TotalStars() =>
			levels.Aggregate(0, (acc, level) => acc + level.CollectedStars());

		/// <summary>
		/// Returns a JSON string representation of this Game Data.
		/// </summary>
		public virtual string ToJson() => JsonUtility.ToJson(this);

		/// <summary>
		/// Returns a new instance of Game Data from a given JSON string.
		/// </summary>
		/// <param name="json">The JSON string to parse.</param>
		public static GameData FromJson(string json) => JsonUtility.FromJson<GameData>(json);
	}
}
