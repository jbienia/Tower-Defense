using UnityEngine;
using System.Collections;

/// <summary>
/// This Class is connected to a Tank Game Object
/// </summary>
public class TankEnemy : Enemy {

    /// <summary>
    /// Update function that checks when the enemy is getting close to a waypoint and needs to advance towards the next waypoint
    /// </summary>
    public override void Update()
    {
        Vector3 waypointPosition;
        waypointPosition.y = wayPoint.position.y;
        waypointPosition.x = wayPoint.position.x;
        waypointPosition.z = wayPoint.position.z;

        dir = waypointPosition - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Checks the distance between the enemy and the way point
        // Determines whether to advance to the next way point
        if (Vector3.Distance(transform.position, waypointPosition) <= 0.4f)
        {

            GetNextWayPoint();
            RotateCharacter();

        }

        // Displays the health bar above the enemy
        healthSliderCanvas.transform.position = DisplayHealthBarAboveEnemy(7f);

        // Rotates the health bar towards the camera
        RotateHealthBar();
    }
}
