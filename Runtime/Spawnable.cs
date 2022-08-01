using UnityEngine;
using UnityEngine.Events;

namespace SpawnSystem
{
	public class Spawnable : MonoBehaviour, ISpawnable
	{
		public UnityEvent<ISpawnPoint> SpawnEvent;

		public string TypeId { get { return tag; } }

		void Awake()
		{
			SpawnEvent = new UnityEvent<ISpawnPoint>();
		}

 		public void Spawn(ISpawnPoint spawnPoint)
		{
			SpawnEvent.Invoke(spawnPoint);
		}
	}
}
