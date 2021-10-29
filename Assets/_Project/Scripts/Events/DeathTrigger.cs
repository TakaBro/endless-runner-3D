using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent _onDeathTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        // Trigger death if player entered death trigger
        if (other.gameObject.GetInstanceID() == GameManager.instance.player.gameObject.GetInstanceID())
        {
            _onDeathTriggerEnter.Raise();
        }
    }
}
