using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointBoundedEvaluator : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;	

		private GameObject boundedObject = null;

		public void SetBoundedObject(GameObject obj)
		{
			boundedObject = obj;
		}

		public void OnSpawned() { }

		public bool Eval(out float cost)
		{
			if (boundedObject != null || !boundedObject.activeInHierarchy)
			{
				cost = 0.0f;
				return false;
			}

			cost = 1.0f;
			return true;
		}
	}
}
