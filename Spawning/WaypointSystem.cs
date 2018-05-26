using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] private float speed = 2f;

    int waypointIndex = 0;

    // Set up for a waypoints list and where they are located
    void Start()
    {
        transform.position = wayPoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // Move object to set waypoint
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, speed * Time.deltaTime);

       if (Vector2.Distance(transform.position, wayPoints[waypointIndex].transform.position) <= 5)
        {
            waypointIndex++;
        }
        
        if (waypointIndex == wayPoints.Count)
        {
            waypointIndex = 0;
        }
    }
}

