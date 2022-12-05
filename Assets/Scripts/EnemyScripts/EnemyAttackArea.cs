using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour,IInteract
{
    private ObjectType type = ObjectType.EnemyArea;

    public void Interact(ObjectType type, Transform tr, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                transform.GetChild(1).GetComponent<EnemyAttackController>().AttackThem(tr);
                Destroy(GetComponent<BoxCollider>());
                action.Invoke(this.type, transform);
                break;

            default:
                break;
        }
    }
}
