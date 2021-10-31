using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameEventIntParameter _OnPlayerExitPlatform;

    private PoolReturn poolReturn;

    private void Awake()
    {
        poolReturn = gameObject.GetComponent<PoolReturn>();
    }

    private void OnEnable()
    {
        RegisterAsListener();
    }

    private void RegisterAsListener()
    {
        _OnPlayerExitPlatform.RegisterListener(poolReturn.CheckInstanceToReturn);
    }

    private void OnDisable()
    {
        UnregisterAsListener();
    }

    private void UnregisterAsListener()
    {
        _OnPlayerExitPlatform.UnregisterListener(poolReturn.CheckInstanceToReturn);
    }
}
