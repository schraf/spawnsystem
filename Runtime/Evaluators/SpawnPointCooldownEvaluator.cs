using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointCooldownEvaluator : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;	

		[SerializeField]
		private float CooldownTime = 0.0f;

		private float LastSpawnTime = float.MinValue;

		public void OnSpawned()
		{
			LastSpawnTime = Time.time;
		}

		public bool Eval(out float cost)
		{
			float now = Time.time;
			float timeSinceLastSpawn = now - LastSpawnTime;

			if (timeSinceLastSpawn < CooldownTime)
			{
				cost = 0.0f;
				return false;
			}

			cost = 1.0f;
			return true;
		}
	}
}
