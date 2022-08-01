namespace SpawnSystem
{
	public interface ISpawnPointEvaluator
	{
		float Weight { get; }
		void OnSpawned(ISpawnable spawnable);
		bool Eval(ISpawnable spawnable, out float cost);
	}
}