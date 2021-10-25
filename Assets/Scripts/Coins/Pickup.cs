using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == PlayerController.player.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
}
