using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameEventIntParameter onCoinPicked;

    [SerializeField]
    private GameObject model;
    private AudioSource audio;

    private void OnEnable()
    {
        model.SetActive(true);
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == GameManager.instance.player.gameObject.GetInstanceID())
        {
            onCoinPicked.Raise(1);
            audio.Play();
            model.SetActive(false);
        }
    }
}
