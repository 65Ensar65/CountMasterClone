using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class GateManager : MyBaseBehaviour,IGate
{
    [SerializeField] TextMeshProUGUI GateText;
    [SerializeField] private int number;

    [SerializeField] GateType gateType;

    public void HitGate(ObjectType Type, System.Action<GateType, int> action)
    {
        switch (Type)
        {
            case ObjectType.Player:
                TouchedPlayer();
                action.Invoke(gateType, number);
                break;
            case ObjectType.Enemy:
                break;
            default:
                break;
        }
    }

    void Start()
    {
        if (gateType == GateType.MultiPly)
        {
            number = Random.Range(2, 3);
            GateText.text = "x" + number;
        }

        else
        {
            number = Random.Range(10, 50);

            if (number % 2 != 0)
            {
                number += 1;
            }
            GateText.text = "+" + number;
        }
    }


    private void TouchedPlayer()
    {
        Destroy(transform.parent.GetChild(0).GetComponent<BoxCollider>());
        Destroy(transform.parent.GetChild(1).GetComponent<BoxCollider>());
    }
   
}

public enum GateType
{
    MultiPly,
    Addition
}
