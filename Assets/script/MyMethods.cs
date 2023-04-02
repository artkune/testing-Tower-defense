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
        for (int i = 1; i < gameObjects.Count; i++)
        {
            float new_HP = gameObjects[i].GetComponent<Enemy>()._HP;
            float old_HP = closestGameObject.GetComponent<Enemy>()._HP;
            if (new_HP > old_HP)
            {
                closestGameObject = gameObjects[i];
            }
        }

        return closestGameObject;
    }
}






