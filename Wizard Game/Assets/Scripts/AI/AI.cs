using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI : MonoBehaviour
{
    private Transform targetPostion;
    // Start is called before the first frame update

    private void Awake()
    {
        //target the player transform
        targetPostion = transform.Find("Player");
    }
    void Start()
    {
        
        //gets seeker component
        Seeker seeker = GetComponent<Seeker>();
        //calculate path
        seeker.StartPath(transform.position, targetPostion.position, OnPathComplete);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPathComplete (Path p)
    {
        Debug.Log("path" + p.error);
    }
}
