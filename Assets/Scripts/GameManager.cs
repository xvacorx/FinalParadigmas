using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject end;
    public int objectCounter;
    private void Start()
    {
        LookForCollectables();
    }
    private void FixedUpdate()
    {
        LookForCollectables();
    }
    public void LookForCollectables()
    {
        GameObject[] objectCount = GameObject.FindGameObjectsWithTag("Collectible");
        objectCounter = objectCount.Length;
        if (objectCounter == 0)
        {
            EnableFinish();
        }
    }
    void EnableFinish()
    {
        end.SetActive(true);
    }
}