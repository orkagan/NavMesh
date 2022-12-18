using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectable
{
    public GameObject door;
    protected override void CollectableTrigger(GameObject collector)
    {
        WaypointMove wpMove = collector.GetComponent<WaypointMove>();
        if (wpMove != null)
        {
            wpMove.waypoints.Remove(gameObject);
            door.GetComponent<UnlockingDoor>().SetLocked(false);
            wpMove.nextPosition();
            Destroy(this.gameObject);
        }
    }
}
