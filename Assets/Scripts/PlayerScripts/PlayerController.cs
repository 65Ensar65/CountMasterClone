using DG.Tweening;
using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class PlayerController : MyBaseBehaviour, IPlayerPoolController
{
    [HideInInspector] public int numberofStickman;

    private ObjectType type = ObjectType.Player;

    private bool IsAttack = false;
    private Transform _otherEnemy;
    private Transform _otherBoss;
    private bool IsBossAttack;

    public TextMeshProUGUI ChildTxt;
    public Transform Player;
    public Transform Tower;
    public Transform Boss;

    [Range(0, 1)][SerializeField] float DistanceFactor;
    [Range(0, 1)][SerializeField] float RadiusFactor;
    public bool _IsAttack
    {
        get
        {
            return IsAttack;
        }
        set
        {
            if (IsAttack)
            {
                e_MoveController.e_rigidbody.velocity = Vector3.zero;


                var enemyDirection = new Vector3(_otherEnemy.transform.position.x, transform.position.y,
                                                 _otherEnemy.transform.position.z) - transform.position;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).rotation = Quaternion.Slerp(transform.GetChild(i).rotation, Quaternion.LookRotation(enemyDirection, Vector3.up), Time.deltaTime * .5f);
                }

                if (_otherEnemy.GetChild(1).childCount > 0)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        var Distance = _otherEnemy.GetChild(1).GetChild(0).position - transform.GetChild(i).position;

                        if (Distance.magnitude < 20f)
                        {
                            transform.GetChild(i).position = Vector3.Lerp(transform.GetChild(i).position,
                                                             new Vector3(_otherEnemy.transform.GetChild(1).GetChild(0).position.x,
                                                                         transform.GetChild(i).position.y,
                                                                         _otherEnemy.transform.GetChild(1).GetChild(0).position.z), Time.deltaTime * .5f);
                        }
                    }
                }

                else
                {
                    Debug.Log("enemyother");
                    IsAttack = false;
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).rotation = Quaternion.Slerp(transform.GetChild(i).rotation, Quaternion.identity, Time.deltaTime * 1f);
                    }

                    GetPoolRound();

                }
            }

            else
            {
                e_MoveController.GetMoveController();
            }
        }
    }
    public bool _IsBossAttack
    {
        get
        {
            return IsBossAttack;
        }
        set
        {
            if (IsBossAttack)
            {
                e_MoveController.e_rigidbody.velocity = Vector3.zero;


                var enemyDirection = new Vector3(_otherBoss.transform.position.x, transform.position.y,
                                                 _otherBoss.transform.position.z) - transform.position;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).rotation = Quaternion.Slerp(transform.GetChild(i).rotation, Quaternion.LookRotation(enemyDirection, Vector3.up), Time.deltaTime * .5f);
                }

                if (_otherBoss.GetChild(0).GetChild(0).childCount > 0)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).position = Vector3.Lerp(transform.GetChild(i).position, Boss.position, 0.01f);
                    }
                }
            }
        }
    }

    private void Start()
    {
        GetChildTxt();
    }
    private void Update()
    {
        GetAttack();
        GetChildTxt();
        Debug.Log(_otherBoss);
    }
    public void GetChildTxt()
    {
        numberofStickman = transform.childCount - 1;
        ChildTxt.text = numberofStickman.ToString();

        if (numberofStickman == 0)
        {
            _otherEnemy.transform.GetChild(1).GetComponent<EnemyAttackController>().StopAttack();
            e_gameManager.GetLosePanel();
            gameObject.SetActive(false);
        }
    }
    public void GetAttack()
    {
        _IsAttack = true;
        _IsBossAttack= true;
    }

    private void SelectFunctionOnTouchedObject(ObjectType touchedType, Transform touchedTransform)
    {
        switch (touchedType)
        {
            case ObjectType.EnemyArea:
                TouchedArea(touchedType, touchedTransform);
                break;
            case ObjectType.BossArea:
                BossTouchedArea(touchedType,touchedTransform);
                Debug.Log("BOssarea");
                break;
            default:
                break;
        }
    }

    private void TouchedArea(ObjectType type, Transform _transform)
    {
        IsAttack = true;
        _otherEnemy = _transform;
    }

    private void BossTouchedArea(ObjectType type , Transform _transform)
    {
        IsBossAttack = true;
        _otherBoss = _transform;
    }

    private void GateCalculate(GateType gateType, int number)
    {
        GameObject obj;
        if (gateType == GateType.MultiPly)
        {
            for (int i = 0; i < (numberofStickman * (number - 1)); i++)
            {
                obj = e_objectpool.ActivePoolObject(ObjectTag.Player, transform);
                obj.transform.localPosition = Vector3.zero;
            }
        }

        if (gateType == GateType.Addition)
        {
            for (int i = 0; i < number; i++)
            {
                obj = e_objectpool.ActivePoolObject(ObjectTag.Player, transform);
                obj.transform.localPosition = Vector3.zero;
            }
        }

        GetPoolRound();

    }
    public void GetPoolRound()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * RadiusFactor);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * RadiusFactor);
            var NewPos = new Vector3(x, 0f, z);

            transform.GetChild(i).DOLocalMove(NewPos, .5f).SetEase(Ease.OutBack);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IGate>()?.HitGate(this.type, GateCalculate);
        other.GetComponent<IInteract>()?.Interact(this.type, transform, SelectFunctionOnTouchedObject);

        
    }
}
