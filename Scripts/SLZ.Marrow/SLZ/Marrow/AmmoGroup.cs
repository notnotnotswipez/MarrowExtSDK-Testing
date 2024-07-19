using System;
using SLZ.Marrow.Data;
using UnityEngine;

namespace SLZ.Marrow
{
	[Serializable]
	[CreateAssetMenu(fileName = "Ammo Group", menuName = "StressLevelZero/Ammo Group", order = 1)]
	public class AmmoGroup : ScriptableObject
	{
		public string KeyName;

		public CartridgeData[] cartridges;
	}
}
