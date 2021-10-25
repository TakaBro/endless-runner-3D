using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    public void CheckInstanceToReturn(int instanceID)
    {
        //Debug.Log("CheckInstanceToReturn: " + instanceID + " == " + this.gameObject.GetInstanceID());
        if (instanceID == this.gameObject.GetInstanceID())
        {
            Invoke("ReturnToPool", Constants.TIME_TO_RETURN_PLATFORM);
        }
    }

    private void ReturnToPool()
    {
        this.gameObject.SetActive(false);
    }
}
