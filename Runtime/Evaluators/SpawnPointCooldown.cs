using UnityEngine;
using System;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointCooldown : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;	

		public float CooldownTime = 0.0f;
		private float LastSpawnTime = float.MinValue;

		public void OnSpawned(ISpawnable spawnable)
		{
			LastSpawnTime = Time.realtimeSinceStartup;
		}

		public bool Eval(ISpawnable spawnable, out float cost)
		{
			float now = Time.realtimeSinceStartup;

			if (now - LastSpawnTime < CooldownTime)
			{
				cost = 0.0f;
				return false;
			}

			cost = Math.Min(1.0f, (now - LastSpawnTime - CooldownTime) / CooldownTime);
			return true;
		}
	}
}
