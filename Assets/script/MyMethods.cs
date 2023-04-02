using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyMethods
{
    public static GameObject MinDistance(this List<GameObject> gameObjects, Transform transform)
    {
        if (gameObjects == null || gameObjects.Count == 0)
        {
            return null;
        }

        GameObject closestGameObject = gameObjects[0];
        float closestDistance = Vector3.Distance(transform.position, closestGameObject.transform.position);

        for (int i = 1; i < gameObjects.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, gameObjects[i].transform.position);
            if (distance < closestDistance)
            {
                closestGameObject = gameObjects[i];
                closestDistance = distance;
            }
        }

        return closestGameObject;
    }
    public static GameObject MaxDistance(this List<GameObject> gameObjects, Transform transform)
    {
        if (gameObjects == null || gameObjects.Count == 0)
        {
            return null;
        }

        GameObject closestGameObject = gameObjects[0];
        float closestDistance = Vector3.Distance(transform.position, closestGameObject.transform.position);

        for (int i = 1; i < gameObjects.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, gameObjects[i].transform.position);
            if (distance > closestDistance)
            {
                closestGameObject = gameObjects[i];
                closestDistance = distance;
            }
        }

        return closestGameObject;
    }
}






