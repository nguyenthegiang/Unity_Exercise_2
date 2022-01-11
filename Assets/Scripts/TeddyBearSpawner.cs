using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A teddy bear spawner: Spawn at 1 of the 3 portals
/// </summary>
public class TeddyBearSpawner : MonoBehaviour
{
	//some code need to run once but after Start -> use this to check first run in Update()
	bool isFirstRun = true;

	// saved for efficiency
	List<GameObject> spaceShips = new List<GameObject>();

	// spawn control
	const float SpawnDelay = 1;
	Timer spawnTimer;

	// spawn location
	int portalNum;

	//get portals array for Spawn Position
	GameObject[] portals = new GameObject[3];

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		//Generate list spaceShips through Resources
		spaceShips.Add((GameObject)Resources.Load(@"Prefabs\spaceship0"));
		spaceShips.Add((GameObject)Resources.Load(@"Prefabs\spaceship1"));
		spaceShips.Add((GameObject)Resources.Load(@"Prefabs\spaceship2"));

		// create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = SpawnDelay;
		spawnTimer.Run();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		if(isFirstRun)
        {
			//get Portal list
			portals = GameObject.FindGameObjectsWithTag("Portal");

			portalNum = portals.Length;

			isFirstRun = false;
        }

		// check for time to spawn a new teddy bear
		if (spawnTimer.Finished)
		{
			SpawnBear();

			// change spawn timer duration and restart
			spawnTimer.Duration = SpawnDelay;
			spawnTimer.Run();
		}
	}

	/// <summary>
	/// Spawns a new teddy bear at a random location
	/// </summary>
	void SpawnBear()
	{
		// generate location from 1 of the Portals to create a Spaceship
		int portalNo = Random.Range(0, portalNum);
		Vector3 location = new Vector3(portals[portalNo].transform.position.x,
									   portals[portalNo].transform.position.y,
									   0);
		//Get random spaceship
		GameObject spaceShip = Instantiate(spaceShips[Random.Range(0, 3)]) as GameObject;
		spaceShip.transform.position = location;
	}
}
