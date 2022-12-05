using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MyBaseBehaviour,IInteract
{
    ObjectType type = ObjectType.BossArea;

    public void Interact(ObjectType type, Transform tr, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                Destroy(GetComponent<BoxCollider>());
                action.Invoke(this.type,tr);
                break;
            default:
                break;
        }
    }
}
