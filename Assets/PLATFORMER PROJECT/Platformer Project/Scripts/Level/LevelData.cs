using System;
using System.Collections.Generic;
using System.Linq;

namespace PLAYERTWO.PlatformerProject
{
	[Serializable]
	public class LevelData
	{
		public bool locked;
		public int coins;
		public List<string> collectedCoins;
        public float time;
		public bool[] stars;
		public int beatenTimes;

		/// <summary>
		/// Returns the amount of stars that have been collected.
		/// </summary>
		public int CollectedStars() => stars?.Where((star) => star).Count() ?? 0;
	}
}