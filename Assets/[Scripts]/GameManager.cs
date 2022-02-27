using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    GameObject floorTilePrefab;
    [SerializeField]
    Vector2 gridSize;

    public float gridOffsetX;
    public float gridOffsetZ;
    public int score;
    public float timer;
    public float timerMax;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        timer = timerMax;
    }

    private void Start()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector3 newposition = new Vector3(gridOffsetX + ((i * 2.8f) + (j * 2.8f) ), 0f, gridOffsetZ + ((i * 2.8f) - (j * 2.8f)));
                GameObject temp = Instantiate(floorTilePrefab,transform);
                temp.transform.position = newposition;
            }
        }
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Floor"))
        {
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().Respawn();
        }
    }
}
