using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MyBaseBehaviour
{
    ObjectType type = ObjectType.Boss;
    int power = 5;
    private void HitToStickman(ObjectType type, Transform _transform)
    {
        transform.PlayAnim((int)AnimState.HIT);
        power--;

        if (power == 0)
        {
            Destroy(gameObject);
            e_gameManager.GetWinPanel();
            transform.PlayAnim((int)PlayerAnimState.IDLE);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(this.type, transform, HitToStickman);
    }
}
public enum AnimState
{
    IDLE,
    HIT
}
