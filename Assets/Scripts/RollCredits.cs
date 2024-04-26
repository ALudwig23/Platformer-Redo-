using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RollCredits : MonoBehaviour
{
    public GameObject SpriteCredits;
    public GameObject AudioCredits;
    public GameObject ReturnToMenu;
    public Cooldown RollCreditScene;

    private WallMovement WallMovement;
    private GameManager GameManager;

    private void Start()
    {
        SpriteCredits.SetActive(false);
        AudioCredits.SetActive(false);
        ReturnToMenu.SetActive(false);
        GameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (WallMovement == null)
        {
            WallMovement = FindObjectOfType<WallMovement>();
        }
        if (WallMovement == null)
            return;

        if (WallMovement.rollCredits == 1)
        {
            SpriteCredits.SetActive(true);

            RollCreditScene.Duration = 5f;

            if (RollCreditScene.CurrentProgress == Cooldown.Progress.Ready)
            {
                RollCreditScene.StartCooldown();
            }
        }

        if (WallMovement.rollCredits == 1 && RollCreditScene.CurrentProgress == Cooldown.Progress.Finished)
        {
            SpriteCredits.SetActive(false);
            WallMovement.rollCredits = 2;
            RollCreditScene.CurrentProgress = Cooldown.Progress.Ready;
        }

        if (WallMovement.rollCredits == 2)
        {
            AudioCredits.SetActive(true);

            RollCreditScene.Duration = 5f;

            if (RollCreditScene.CurrentProgress == Cooldown.Progress.Ready)
            {
                RollCreditScene.StartCooldown();
            }
        }

        if (WallMovement.rollCredits == 2 && RollCreditScene.CurrentProgress == Cooldown.Progress.Finished)
        {
            AudioCredits.SetActive(false);
            WallMovement.rollCredits = 3;
            RollCreditScene.CurrentProgress = Cooldown.Progress.Ready;
        }

        if (WallMovement.rollCredits == 3)
        {
            ReturnToMenu.SetActive(true);

            if (Input.anyKeyDown)
            {
                GameManager.ToNextLevel();
            }
        }
    }
}
