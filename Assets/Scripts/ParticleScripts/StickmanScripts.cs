using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanScripts : MyBaseBehaviour,IInteract
{
    public ObjectType objectType;

    public void Interact(ObjectType type, Transform tr, Action<ObjectType, Transform> action)
    {
        switch (objectType)
        {
            case ObjectType.Player:
                //GameObject Pos = e_objectpool.ActivePoolObject(ObjectTag.BloodBlue, transform);
                action(type, tr);
                break;

            case ObjectType.Enemy:
                action(type, tr);
                break;
            case ObjectType.Boss:
                action(type, tr);
                break;
            default:
                break;
        }
    }

}
