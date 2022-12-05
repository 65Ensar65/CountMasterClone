using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBaseBehaviour : MonoBehaviour
{
    [HideInInspector] public Rigidbody e_rigidbody;
    [HideInInspector] public Collider e_collider;
    [HideInInspector] public Animator e_animator;
    [HideInInspector] public Joystick e_joystick;
    [HideInInspector] public ObjectPool e_objectpool;
    [HideInInspector] public GateManager e_gatemanager;
    [HideInInspector] public PlayerAnimatorController e_animatorControl;
    [HideInInspector] public PlayerMoveController e_MoveController;
    [HideInInspector] public PlayerController e_playerController;
    [HideInInspector] public EnemyAttackController e_attackEnemy;
    [HideInInspector] public EnemyObjectPool e_enemyObjectPool;
    [HideInInspector] public GameManager e_gameManager;
    [HideInInspector] public BossController e_bossController;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        e_rigidbody = (GetComponent<Rigidbody>()) ? GetComponent<Rigidbody>() : null;
        e_collider = (GetComponent<Collider>()) ? GetComponent<Collider>() : null;
        e_animator = (GetComponent<Animator>()) ? GetComponent<Animator>() : null;
        e_objectpool = (FindObjectOfType<ObjectPool>()) ? FindObjectOfType<ObjectPool>() : null;
        e_joystick = (FindObjectOfType<Joystick>()) ? FindObjectOfType<Joystick>() : null;
        e_gatemanager = (GetComponent<GateManager>()) ? GetComponent<GateManager>() : null;
        e_animatorControl = (FindObjectOfType<PlayerAnimatorController>()) ? FindObjectOfType<PlayerAnimatorController>() : null;
        e_MoveController = (FindObjectOfType<PlayerMoveController>()) ? FindObjectOfType<PlayerMoveController>() : null;
        e_playerController = (FindObjectOfType<PlayerController>()) ? FindObjectOfType<PlayerController>() : null;
        e_attackEnemy = GetComponent<EnemyAttackController>() ? GetComponent<EnemyAttackController>() : null;
        e_enemyObjectPool = (FindObjectOfType<EnemyObjectPool>()) ? FindObjectOfType<EnemyObjectPool>() : null;
        e_gameManager = (FindObjectOfType<GameManager>()) ? FindObjectOfType<GameManager>() : null;
        e_bossController = (FindObjectOfType<BossController>()) ? FindObjectOfType<BossController>() : null;
    }
}
