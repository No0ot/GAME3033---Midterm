using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject floorTilePrefab;
    [SerializeField]
    Vector2 gridSize;

    private void Start()
    {

        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector3 newposition = new Vector3(i * 4f, 0f, j * 4);
                GameObject temp = Instantiate(floorTilePrefab);
                temp.transform.position = newposition;
            }
        }
    }
}
