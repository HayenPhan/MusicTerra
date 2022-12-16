using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 GetRandomSpawnPoint()
    {
        // Random spawn point is too buggy. Character gets stuck at specific points (especially when it spawns on the left side)
        return new Vector3(0.3f, 0f, -0.7f);
        // return new Vector3(1f, 0, -0.65f);

        // Use a fixed spawn point to fix this problem
        // return new Vector3(2f, 0.1f, -1.5f);

        // return new Vector3(Random.Range(-20, 20), 4, Random.Range(-20, 20));
    }
}
