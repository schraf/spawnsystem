using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointRandom : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;

		public void OnSpawned(ISpawnable spawnable) { }

		public bool Eval(ISpawnable spawnable, out float cost)
		{
			cost = Random.value;
			return true;
		}
	}
}
