using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : Collectable
{
    protected override void CollectableTrigger(GameObject collector)
    {
        WaypointMove wpMove = collector.GetComponent<WaypointMove>();
        if (wpMove != null)
        {
            wpMove.waypoints.Remove(gameObject);
            wpMove.nextPosition();
            Destroy(this.gameObject);
        }
    }
}
