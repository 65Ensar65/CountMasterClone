using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStickmanController : MyBaseBehaviour
{
    ObjectType type = ObjectType.Player;
    public GameObject _gameObject;
    private void HitToStickman(ObjectType type, Transform _transform)
    {
        e_objectpool.ReturnPoolObject(ObjectTag.Player, gameObject);
        e_playerController.numberofStickman--;
        transform.parent= null;
        Debug.Log("EnemyHitt");
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(this.type, transform, HitToStickman);

        if (other.CompareTag("Ramp"))
        {
            transform.DOLocalJump(transform.localPosition, 5, 1, 1).SetEase(Ease.Flash);
        }
    }
}
