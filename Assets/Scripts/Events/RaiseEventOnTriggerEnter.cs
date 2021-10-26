using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private GameEvent onTriggerEnter;
    [SerializeField] private string tag;

    private void OnTriggerEnter(Collider other)
    {
        if (tag == other.tag)
        {
            onTriggerEnter.Raise();
        }
    }
}
