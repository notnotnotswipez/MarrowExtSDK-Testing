using SLZ.Marrow.AI;
using SLZ.Marrow.Zones;
using UltEvents;
using UnityEngine;

public class SpawnDeathEvent : SpawnDecorator
{
	public UltEvent<AIBrain> OnDeathEvent;

	public void OnDeath(AIBrain brain)
	{
	}
}
