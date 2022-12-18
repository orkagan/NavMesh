using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public string collectorName;
    protected abstract void CollectableTrigger(GameObject collector);
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} collected");
        if (other.name == collectorName)
        {
            CollectableTrigger(other.gameObject);
        }
    }
}
