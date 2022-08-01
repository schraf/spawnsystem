using UnityEngine;

namespace SpawnSystem
{
	public interface ISpawnPoint
	{
		Vector3 Location { get; }

		bool Eval(ISpawnable spawnable, out float cost);
		void OnSpawned(ISpawnable spawnable);
	}
}