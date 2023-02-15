using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public enum SpawnPointDistanceEvaluatorMode
	{
		InsideDistance,
		OutsideDistance
	}

	public class SpawnPointDistanceEvaluator : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;

		[SerializeField]
		private string targetTag = "Player";

		[SerializeField]
		private float targetDistance = 10.0f;

		[SerializeField]	
		private int requiredNumberOfObjects = 1;

		[SerializeField]
		private SpawnPointDistanceEvaluatorMode distanceMode = SpawnPointDistanceEvaluatorMode.InsideDistance;

		[SerializeField]
		private bool use2dDistanceCheck = true;

		public void OnSpawned() { }

		public bool Eval(out float cost)
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(targetTag);
			cost = 0.0f;

			if (gameObjects.Length < requiredNumberOfObjects)
			{
				return false;
			}

			foreach (GameObject gameObject in gameObjects)
			{
				float distanceSqr = 0.0f;
				
				if (use2dDistanceCheck)
				{
					Vector2 pos1 = new Vector2(transform.position.x, transform.position.z);
					Vector2 pos2 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
					distanceSqr = (transform.position - gameObject.transform.position).sqrMagnitude;	
				}
				else
				{
					distanceSqr = (transform.position - gameObject.transform.position).sqrMagnitude;
				} 

				if ((distanceMode == SpawnPointDistanceEvaluatorMode.InsideDistance && distanceSqr < targetDistance*targetDistance) ||
					(distanceMode == SpawnPointDistanceEvaluatorMode.OutsideDistance && distanceSqr > targetDistance*targetDistance))
				{
					cost += 1.0f;

					if (cost >= requiredNumberOfObjects)
						break;
				}
			}

			cost = cost / requiredNumberOfObjects;
			return true;
		}
	}
}
