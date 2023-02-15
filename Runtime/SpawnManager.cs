using UnityEngine;
using System.Collections.Generic;

namespace SpawnSystem
{
	public class SpawnManager : MonoBehaviour
	{
		private List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

		public void RegisterSpawnPoint(SpawnPoint spawnPoint)
		{
			SpawnPoints.Add(spawnPoint);
		}

		public void DeregisterSpawnPoint(SpawnPoint spawnPoint)
		{
			SpawnPoints.Remove(spawnPoint);
		}

		public void AttemptSpawn()
		{
			SpawnPoint bestSpawnPoint = null;
			float bestCost = float.PositiveInfinity;

			foreach (SpawnPoint spawnPoint in SpawnPoints)
			{
				float cost = float.NaN;

				if (spawnPoint.Eval(out cost) && (bestSpawnPoint == null || cost < bestCost))
				{
					bestSpawnPoint = spawnPoint;
					bestCost = cost;
				}
			}

			if (bestSpawnPoint)
			{
				bestSpawnPoint.Spawn();
			}
		}
	}
}