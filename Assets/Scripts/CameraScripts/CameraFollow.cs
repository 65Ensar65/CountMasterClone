using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 Offset;
    [SerializeField] Transform Player;
    void LateUpdate()
    {
        transform.position = Player.position + Offset;
    }
}
