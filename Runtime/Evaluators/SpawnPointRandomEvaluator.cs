using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointRandomEvaluator : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;

		public void OnSpawned() { }

		public bool Eval(out float cost)
		{
			cost = Random.value;
			return true;
		}
	}
}
