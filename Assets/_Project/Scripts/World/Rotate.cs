using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private float _rotationAmount;
    void Update()
    {
        _rotationAmount = _speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, _rotationAmount, 0));
    }
}
