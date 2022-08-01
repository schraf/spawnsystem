namespace SpawnSystem
{
	public interface ISpawnable
	{
		string TypeId { get; }

		void Spawn(ISpawnPoint spawnPoint);
	}
}