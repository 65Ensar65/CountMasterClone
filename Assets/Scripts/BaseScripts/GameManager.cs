using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MyBaseSingleton<GameManager>
{
    [SerializeField] GameObject TapToStart;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject CanvasGroup;
    public void GetTapToStart()
    {
        TapToStart.SetActive(false);
        e_animatorControl.GetAnimator();
        e_MoveController.MoveSpeed = 8f;
    }

    public void GetWinPanel()
    {
        WinPanel.SetActive(true);
        CanvasGroup.SetActive(false);
    }

    public void GetLosePanel()
    {
        LosePanel.SetActive(true);
        CanvasGroup.SetActive(false);
    }
}
