using UnityEngine;
using System.Collections;

public class TankEnemy : Enemy {

    // Update is called once per frame
    public override void Update()
    {
        //wayPoint.position.y += 2;
        Vector3 test;
        test.y = wayPoint.position.y;
        test.x = wayPoint.position.x;
        test.z = wayPoint.position.z;

        dir = test - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Checks the distance between the enemy and the way point
        // Determines whether to advance to the next way point
        if (Vector3.Distance(transform.position, test) <= 0.4f)
        {

            GetNextWayPoint();
            RotateCharacter();

        }

        //healthSliderCanvas.transform.position = DisplayHealthBarAboveEnemy();
        healthSliderCanvas.transform.position = DisplayHealthBarAboveEnemy(7f);
        RotateHealthBar();

    }

}
