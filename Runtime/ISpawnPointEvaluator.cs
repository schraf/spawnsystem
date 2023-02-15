namespace SpawnSystem
{
	public interface ISpawnPointEvaluator
	{
		float Weight { get; }
		void OnSpawned();
		bool Eval(out float cost);
	}
}