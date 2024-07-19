using System.Collections.Generic;
using UnityEngine;

namespace SLZ.Marrow.Warehouse
{
	public class CampaignData : DataCard
	{
		[SerializeField]
		private List<LevelCrateReference> _levels;

		public List<LevelCrateReference> Levels => null;

		public override bool IsBundledDataCard()
		{
			return false;
		}
	}
}
