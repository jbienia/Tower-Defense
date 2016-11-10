using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlyingEnemy : Enemy
{


    /// <summary>
    /// Overrides the Update() of the base class
    /// Adjusts the y position so that the enemy doesn't fly down to the waypoints that are located on the ground
    /// </summary>
    public override void Update()
    {

        Vector3 wayPointPosition;
        wayPointPosition.y = wayPoint.position.y + 4;
        wayPointPosition.x = wayPoint.position.x;
        wayPointPosition.z = wayPoint.position.z;

        dir = wayPointPosition - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Checks the distance between the enemy and the way point
        // Determines whether to advance to the next way point
        if (Vector3.Distance(transform.position, wayPointPosition) <= 0.4f)
        {
            Debug.Log("I want to move!");
            GetNextWayPoint();
            
        }

        RotateCharacter();

        // Displays the health bar above the enemy
        healthSliderCanvas.transform.position = DisplayHealthBarAboveEnemy(7f);

        // Rotates the health bar towards the camer
        RotateHealthBar();
    }
}
