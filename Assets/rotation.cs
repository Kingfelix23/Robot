using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCKilledCounter : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    bool _growingAngle = true;

    private void Update()
    {
        transform.Rotate((_growingAngle ? Vector3.forward : Vector3.back) * Time.deltaTime * _speed);

        if (_growingAngle && transform.rotation.eulerAngles.x >= 180)
        {
            _growingAngle = false;
            return;
        }
        if (transform.rotation.eulerAngles.x <= 0) _growingAngle = true;
    }
}