using System;
using UnityEngine;
public interface IObstackle
{

}

public interface IGate
{
    void HitGate(ObjectType gateType , Action<GateType,int> action);
}

public interface IInteract
{
    void Interact(ObjectType type, Transform tr, Action<ObjectType, Transform> action);
}

public interface IParticleBlood
{
    void Blood(ObjectType type, Transform _transform, Quaternion _quaternion, Action<ObjectType, Transform, Quaternion> action);
}

public interface IPlayerObjectPool
{
    void GetPoolManager();
    GameObject ActivePoolObject(ObjectTag _objectTag, Transform _player);
    GameObject ReturnPoolObject(ObjectTag _objectTag, GameObject _obj);
}

public interface IEnemyObjectPool
{
    void GetPoolManager();
    GameObject ActivePoolObject(ObjectTags _objectTag, int _size, Transform _player);
}

public interface IPlayerPoolController
{
    void GetChildTxt();
    void GetAttack();
}

public interface IEnemyPoolController
{
    void AttackThem(Transform _enemyForce);
    void GetAttack();

    void GetChildTxt();
}

public interface IPlayerMovecontrol
{
    void GetMoveController();
}

public interface IGameManagerControl
{
    void GetTapToStart();
    void GetWinPanel();
    void GetLosePanel();
}

public enum ObjectType
{
    Player,
    Enemy,
    Gate,
    EnemyArea,
    BlueBlood,
    RedBlood,
    Ramp,
    Boss,
    BossArea
}
