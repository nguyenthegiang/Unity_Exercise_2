using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Teddy Bear
/// </summary>
public class TeddyBear : MonoBehaviour
{
    //total number of collisions
    int totalCollisions = 0;
    // death support
    const float TeddyBearLifespanSeconds = 10;
    Timer deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        //get the game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            //vector * float = force vector
            direction * magnitude,
            ForceMode2D.Impulse);

        // create and start timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = TeddyBearLifespanSeconds;
        deathTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // kill teddy bear if death timer finished
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called on a collision
    /// </summary>
    /// <param name="collision">collision info</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when teddy bear collide with something
        totalCollisions++;
        print("Total number of Collisions: " + totalCollisions);
        switch (collision.gameObject.tag)
        {
            case "LeftEdge":
                {
                    print("Touched Left Edge");
                    break;
                }
            case "RightEdge":
                {
                    print("Touched Right Edge");
                    break;
                }
            case "TopEdge":
                {
                    print("Touched Top Edge");
                    break;
                }
            case "BottomEdge":
                {
                    print("Touched Bottom Edge");
                    break;
                }
            case "TeddyBear":
                {
                    Destroy(gameObject);
                    break;
                }
        }
    }
}