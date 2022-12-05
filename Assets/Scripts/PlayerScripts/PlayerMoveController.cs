using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MyBaseBehaviour,IPlayerMovecontrol
{
    [SerializeField] float SwipeClamp;
    [SerializeField] float SwipeSpeed;
     public float MoveSpeed;
    public void GetMoveController()
    {
        e_rigidbody.velocity = new Vector3(0, 0, MoveSpeed);
        //transform.position += Vector3.forward * MoveSpeed;

        if (e_joystick.Horizontal != 0)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + (e_joystick.Horizontal * SwipeSpeed * Time.deltaTime), -SwipeClamp, SwipeClamp),
                                                         transform.position.y,
                                                         transform.position.z);
        }   
    }
}
