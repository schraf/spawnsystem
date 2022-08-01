using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointDesireDistance : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;

		public string DesireTag;
		public float MaxDistance;
		public int MaxObjects;

		public void OnSpawned(ISpawnable spawnable) { }

		public bool Eval(ISpawnable spawnable, out float cost)
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(DesireTag);
			cost = 0.0f;

			if (gameObjects.Length == 0)
			{
				cost = 0.0f;
				return false;
			}

			foreach (GameObject gameObject in gameObjects)
			{
				float distance = Vector3.Distance(transform.position, gameObject.transform.position);

				if (distance < MaxDistance)
				{
					cost += 1.0f;

					if (cost >= MaxObjects)
						break;
				}
			}

			cost = cost / MaxObjects;
			return true;
		}
	}
}
