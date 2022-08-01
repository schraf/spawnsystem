using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SpawnSystem
{
	public class SpawnPoint : MonoBehaviour, ISpawnPoint
	{
		public UnityEvent<ISpawnPoint, ISpawnable> SpawnEvent;
		public SpawnManager Manager;
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

		public Vector3 Location { get { return transform.position; } }

		public bool Eval(ISpawnable spawnable, out float cost)
		{
			cost = 0.0f;

			foreach (ISpawnPointEvaluator evaluator in Evaluators)
			{
				float evaluatorCost = 0.0f;

				if (evaluator.Eval(spawnable, out evaluatorCost))
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

		public void OnSpawned(ISpawnable spawnable)
		{
			foreach (ISpawnPointEvaluator evaluator in Evaluators)
			{
				evaluator.OnSpawned(spawnable);
			}

			SpawnEvent.Invoke(this, spawnable);
		}
	}
}
