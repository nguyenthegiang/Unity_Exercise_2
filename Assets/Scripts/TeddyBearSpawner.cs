using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A teddy bear spawner
/// </summary>
public class TeddyBearSpawner : MonoBehaviour
{
	// needed for spawning
	//[SerializeField] -> visible in the inspector

	// saved for efficiency
	List<GameObject> spaceShips = new List<GameObject>();

	// spawn control
	const float MinSpawnDelay = 1;
	const float MaxSpawnDelay = 2;
	Timer spawnTimer;

	// spawn location support
	const int SpawnBorderSize = 100;
	int minSpawnX;
	int maxSpawnX;
	int minSpawnY;
	int maxSpawnY;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		//Generate list spaceShips through Resources
		spaceShips.Add((GameObject)Resources.Load(@"Prefabs\spaceship0"));
		spaceShips.Add((GameObject)Resources.Load(@"Prefabs\spaceship1"));
		spaceShips.Add((GameObject)Resources.Load(@"Prefabs\spaceship2"));

		// save spawn boundaries for efficiency
		minSpawnX = SpawnBorderSize;
		maxSpawnX = Screen.width - SpawnBorderSize;
		minSpawnY = SpawnBorderSize;
		maxSpawnY = Screen.height - SpawnBorderSize;

		// create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
		spawnTimer.Run();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// check for time to spawn a new teddy bear
		if (spawnTimer.Finished)
		{
			SpawnBear();

			// change spawn timer duration and restart
			spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
			spawnTimer.Run();
		}
	}

	/// <summary>
	/// Spawns a new teddy bear at a random location
	/// </summary>
	void SpawnBear()
	{
		// generate random location and create new teddy bear
		Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
									   Random.Range(minSpawnY, maxSpawnY),
									   -Camera.main.transform.position.z);
		Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
		//Get random spaceship
		GameObject spaceShip = Instantiate(spaceShips[Random.Range(0, 3)]) as GameObject;
		spaceShip.transform.position = worldLocation;
	}
}
