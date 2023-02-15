using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SpawnSystem
{
	public class SpawnPoint : MonoBehaviour
	{
		public UnityEvent<GameObject> SpawnEvent;

		[SerializeField]
		private SpawnManager Manager;

		private List<ISpawnPointEvaluator> Evaluators = new List<ISpawnPointEvaluator>();

		public void Start()
		{
			foreach (ISpawnPointEvaluator evaluator in GetComponents<ISpawnPointEvaluator>())
			{
				Evaluators.Add(evaluator);
			}

			Manager.RegisterSpawnPoint(this);
		}

		public void OnDestroy()
		{
			Manager.DeregisterSpawnPoint(this);
		}

		public bool Eval(out float cost)
		{
			cost = 0.0f;

			foreach (ISpawnPointEvaluator evaluator in Evaluators)
			{
				float evaluatorCost = 0.0f;

				if (evaluator.Eval(out evaluatorCost))
				{
					cost += (evaluatorCost * evaluator.Weight);
				}
				else
				{
					return false;
				}
			}

			return true;
		}

		public void Spawn()
		{
			foreach (ISpawnPointEvaluator evaluator in Evaluators)
			{
				evaluator.OnSpawned();
			}

			if (SpawnEvent != null)
			{
				SpawnEvent.Invoke(gameObject);
			}
		}
	}
}
