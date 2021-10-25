using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float RotationAmount;
    void Update()
    {
        RotationAmount = speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, RotationAmount, 0));
    }
}
