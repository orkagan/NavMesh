using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndObject : MonoBehaviour
{
    protected void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{other.gameObject.name} finished!");
        WaypointMove wpMove = other.gameObject.GetComponent<WaypointMove>();
        if (wpMove != null)
        {
            wpMove.Finished();
        }
    }
}
