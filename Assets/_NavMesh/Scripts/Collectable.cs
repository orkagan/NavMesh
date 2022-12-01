using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        WaypointMove wpMove = other.GetComponent<WaypointMove>();
        if (wpMove != null && other.tag == "Agent")
        {
            wpMove.nextPosition();
            Destroy(this.gameObject);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        WaypointMove wpMove = collision.gameObject.GetComponent<WaypointMove>();
        if (wpMove != null && collision.gameObject.tag == "Agent")
        {
            wpMove.nextPosition();
            Debug.Log("nextPosition");
            Destroy(this.gameObject);
        }
    }*/
}
