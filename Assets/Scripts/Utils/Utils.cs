using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-2.6f, 2f), 0.05f, Random.Range(-1.5f, 3f));
    }
}
