using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make 3 Portal at Random Location from which the Spaceships will be spawned
/// </summary>
public class PortalSpawner : MonoBehaviour
{
    // spawn location support
    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        GameObject portal = (GameObject)Resources.Load(@"Prefabs\portal");

        // spawn boundaries
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        //spawn 3 Portals
        for (int i = 0; i < 3; i++)
        {
            spawnPortal(portal);
        }
        
    }

    /// <summary>
    /// Spawn a Portal at Random Location
    /// </summary>
    void spawnPortal(GameObject portal)
    {
        // generate random location and create new portal
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
                                       Random.Range(minSpawnY, maxSpawnY),
                                       -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject thisPortal = Instantiate(portal) as GameObject;
        thisPortal.tag = "Portal";
        thisPortal.transform.position = worldLocation;
    }
}
