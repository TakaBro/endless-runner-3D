using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField]
    private GameObject _lastPlatform;
    private GameObject _dummyTraveller;

    public void RunDummy()
    {
        Debug.Log("RunDummy");
        GameObject p = ObjectPool.instance.GetRandom();
        if (p == null) return;

        if (_lastPlatform != null)
        {
            _dummyTraveller.transform.position = _lastPlatform.transform.position +
                GameManager.instance.player.gameObject.transform.forward * Constants.PLATFORM_LENGTH;
        }

        _lastPlatform = p;
        p.SetActive(true);
        p.transform.position = _dummyTraveller.transform.position;
        p.transform.rotation = _dummyTraveller.transform.rotation;
    }

    void Awake()
    {
        _dummyTraveller = new GameObject("dummy");
    }

    private void Start()
    {
        RunDummy();
    }
}
