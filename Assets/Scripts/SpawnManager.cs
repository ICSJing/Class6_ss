using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstablePrefab;
    [SerializeField] private Transform spawnPt;

    private float startDelay = 2;
    private float repeatRate = 2;
    List<Obstacle> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<Obstacle>();
    }
    private void OnEnable()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void OnDisable()
    {
        CancelInvoke();
        //disable active obstacles
        for(int i = 0; i < obstacles.Count; i++)
        {
            if(obstacles[i] != null)
            {
                obstacles[i].enabled = false;
            }
        }
    }
    private void SpawnObstacle()
    {
       GameObject obj = Instantiate(obstablePrefab, spawnPt.position, spawnPt.transform.rotation); //rotation is default
       Obstacle obstacle = obj.GetComponent<Obstacle>();
       obstacles.Add(obstacle);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
