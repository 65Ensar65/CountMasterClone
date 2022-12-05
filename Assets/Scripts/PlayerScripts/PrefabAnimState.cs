using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabAnimState : MyBaseBehaviour
{
    public void aaa()
    {
        e_animator.SetInteger("Run",1);
    }
}
public enum PrefabAnimstate
{
    RUN,
    IDLE
}
