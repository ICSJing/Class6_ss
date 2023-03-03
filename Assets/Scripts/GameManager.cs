using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Background background;
    [SerializeField] private SpawnManager spawnManager;

    public void EndGame()
    {
        Debug.Log("EndGame");
        background.enabled = false;
        spawnManager.enabled = false;

        StartCoroutine(WaitToReset());

    }

    IEnumerator WaitToReset()
    {
        yield return new WaitForSeconds(3.0f);
       Reset();



    }
    public void Reset()
    { 
         spawnManager.DestroyObstacles();
    
        spawnManager.enabled = true;
        background.enabled = true;
        playerController.Reset();
    }

}
