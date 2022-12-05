using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class EnemyAttackController : MyBaseBehaviour,IEnemyPoolController
{
    private bool IsAttack;
    [HideInInspector] public int numberOfStickman;
    private Transform EnemyForce;

    public GameObject ParentObj;
    public bool _isAnimControl;
    public TextMeshProUGUI ChildTxt;
    [Range(0, 1)] public float Radius, DistanceFactor;

    private ObjectType type = ObjectType.Enemy;

    public bool _IsAttack
    {
        get
        {
            return IsAttack;
        }
        set
        {
            if (IsAttack && transform.childCount > 0)
            {
                var enemyPos = new Vector3(EnemyForce.transform.position.x, transform.position.y, EnemyForce.transform.position.z);
                var enemyDirection = EnemyForce.position - transform.position;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).rotation = Quaternion.Slerp(transform.GetChild(i).rotation, Quaternion.LookRotation(enemyDirection, Vector3.up), Time.deltaTime * .5f);

                    var Distance = EnemyForce.GetChild(1).position - transform.GetChild(i).position;

                    if (Distance.magnitude < 20)
                    {
                        transform.GetChild(i).position = Vector3.Lerp(transform.GetChild(i).position,
                                                                      EnemyForce.GetChild(1).position, Time.deltaTime * .5f);

                    }
                }
            }
        }
    }

    private void Start()
    {
        EnemyRound();
    }

    void Update()
    {
        GetAttack();
        GetChildTxt();
    }

    public void GetChildTxt()
    {
        numberOfStickman = transform.childCount;
        ChildTxt.text = numberOfStickman.ToString();

        if (numberOfStickman == 0)
        {
            Destroy(ParentObj);
        }
    }
    public void AttackThem(Transform _enemyForce)
    {
        EnemyForce = _enemyForce;
        IsAttack = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).PlayAnim((int)EnemyState.RUN);
        }
    }  

    public void StopAttack()
    {
        IsAttack = false;
        Debug.Log("StopAttack");

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).PlayAnim((int)EnemyState.IDLE);
        }
    }
    public void GetAttack()
    {
        _IsAttack = true;
    }

    public void EnemyRound()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(Radius * i);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(Radius * i);

            var newPos = new Vector3(x, 0, z);

            transform.GetChild(i).DOLocalMove(newPos, .5f).SetEase(Ease.OutBack);
        }
    }
}

public enum EnemyState
{
    IDLE,
    RUN
}