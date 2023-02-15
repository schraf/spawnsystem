using UnityEngine;

namespace SpawnSystem.Evaluators
{
	public class SpawnPointLockableEvaluator : MonoBehaviour, ISpawnPointEvaluator
	{
		[field: SerializeField]
		public float Weight { get; set; } = 1.0f;

		[SerializeField]
		private bool locked = false;

		public void Toggle()
		{
			locked = !locked;
		}

		public void Lock()
		{
			locked = true;
		}

		public void Unlock()
		{
			locked = false;
		}

		public void OnSpawned() { }

		public bool Eval(out float cost)
		{
			if (locked)
			{
				cost = 0.0f;
				return false;
			}

			cost = 1.0f;
			return true;
		}
	}
}
