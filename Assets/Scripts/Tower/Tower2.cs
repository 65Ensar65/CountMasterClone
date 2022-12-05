using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    [SerializeField] float Y_Offset = 0;
    [SerializeField] float Z_Offset;

    int posY;
    void Update()
    {
    }

    void CountTower()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).DOLocalMove(transform.localPosition + new Vector3(0,Y_Offset,0),100);
            //transform.GetChild(i).DOLocalMoveY(0, 2);
            Y_Offset++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish2"))
        {
            CountTower();
        }
    }
}
