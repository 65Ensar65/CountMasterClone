using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStickmanController : MyBaseBehaviour
{
    ObjectType type = ObjectType.Enemy;
    private void HitToStickman(ObjectType type, Transform _transform)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(this.type, transform, HitToStickman);
    }
}
