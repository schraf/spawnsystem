using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointTypeRestriction : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;

		public string TypeId;

		public void OnSpawned(ISpawnable spawnable) { }

		public bool Eval(ISpawnable spawnable, out float cost)
		{
			if (spawnable.TypeId == TypeId)
			{
				cost = 1.0f;
				return true;
			}

			cost = 0.0f;
			return false;
		}
	}
}
