using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField]
    private GameObject lastPlatform;
    private GameObject dummyTraveller;

    void Awake()
    {
        dummyTraveller = new GameObject("dummy");
    }

    private void Start()
    {
        RunDummy();
    }

    public void RunDummy()
    {
        GameObject p = ObjectPool.instance.GetRandom();
        if (p == null) return;

        if (lastPlatform != null)
        {
            dummyTraveller.transform.position = lastPlatform.transform.position +
                PlayerController.player.transform.forward * Constants.PLATFORM_LENGTH;
        }

        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;
    }
}
