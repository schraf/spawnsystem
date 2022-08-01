using UnityEngine;
using System.Collections.Generic;

namespace SpawnSystem
{
	public class SpawnManager : MonoBehaviour
	{
		private List<ISpawnPoint> SpawnPoints = new List<ISpawnPoint>();

		public void RegisterSpawnPoint(ISpawnPoint spawnPoint)
		{
			SpawnPoints.Add(spawnPoint);
		}

		public void DeregisterSpawnPoint(ISpawnPoint spawnPoint)
		{
			SpawnPoints.Remove(spawnPoint);
		}

		public bool Spawn(ISpawnable spawnable)
		{
			ISpawnPoint bestSpawnPoint = null;
			float bestCost = float.PositiveInfinity;

			foreach (ISpawnPoint spawnPoint in SpawnPoints)
			{
				float cost = float.NaN;

				if (spawnPoint.Eval(spawnable, out cost) && (bestSpawnPoint == null || cost < bestCost))
				{
					bestSpawnPoint = spawnPoint;
					bestCost = cost;
				}
			}

			if (bestSpawnPoint != null)
			{
				spawnable.Spawn(bestSpawnPoint);
				bestSpawnPoint.OnSpawned(spawnable);
				return true;
			}

			return false;
		}
	}

}