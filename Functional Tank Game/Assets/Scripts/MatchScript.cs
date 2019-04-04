using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchScript : MonoBehaviour
{

    public float matchTime;
    private int displayTime;
    public Text timeText;
    public float startTime;
    private float startTrigger = 0f;

    public PlayerTank1 player1;
    public PlayerTank2 player2;
    public Text winText;

    public float disableTimeText;
    public float returnTiTitle;

    public Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        displayTime = (int)matchTime;
        timerText.text = displayTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        startTrigger += Time.deltaTime;

        if (startTrigger >= startTime)
        {
            if (player1.currentHealth > 0 && player2.currentHealth > 0)
            {
                /* Turn Dictator */
                turnDetermine(player1, player2);

                /* Start Match */
                matchTime -= Time.deltaTime;
                displayTime = (int)matchTime;
                timerText.text = displayTime.ToString();

                if (matchTime < 0)
                {
                    player1.enabled = false;
                    player2.enabled = false;
                    timerText.text = "0";
                    if (matchTime <= disableTimeText)
                    {
                        if (player1.currentHealth > player2.currentHealth)
                        {
                            winText.text = "Player 1 Wins!";
                        }
                        else if (player1.currentHealth < player2.currentHealth)
                        {
                            winText.text = "Player 2 Wins!";
                        }
                        else if (player1.currentHealth == player2.currentHealth)
                        {
                            winText.text = "Draw!";
                        }
                    }
                    else
                    {
                        winText.text = "Time!";
                    }
                }

            }
            else
            {
                player1.enabled = false;
                player2.enabled = false;
                if (player1.currentHealth <= 0 && player2.currentHealth > 0)
                {
                    winText.text = "Player 2 Wins!";
                }
                else if (player2.currentHealth <= 0 && player1.currentHealth > 0)
                {
                    winText.text = "Player 1 Wins!";
                }
                else if (player1.currentHealth <= 0 && player2.currentHealth <= 0)
                {
                    winText.text = "Draw!";
                }
            }
        }

        if (matchTime <= (returnToTitle))
        {
            //animate.SetBool("Exit", true);
            SceneManager.LoadScene(sceneBuildIndex: 0);

        }

    } // end update


    void turnDetermine(PlayerTank1 player1, PlayerTank2 player2)
    {
        if (player1.turnCheck == false && player2.turnCheck == false)
        {
            player1.turnCheck = true;
        }
        else if (player1.turnCheck == true)
        {
            player2.turnCheck = false;
            if (player1.firedProjectile == true)
            {
                player1.turnCheck == false;
                player2.turnCheck == true;
            }
            else if (player1.movementComplete == true)
            {
                player1.turnCheck == false;
                player2.turnCheck == true;
            }
        }
        else if (player2.turnCheck == true)
        {
            player1.turnCheck = false;
            if (player2.firedProjectile == true)
            {
                player1.turnCheck == true;
                player2.turnCheck == false;
            }
            else if (player2.movementComplete == true)
            {
                player1.turnCheck == true;
                player2.turnCheck == false;
            }
        }
        else if (matchTime == 0)
        {
            player1.turnCheck = false;
            player2.turnCheck = false;
        }

    } // end turnDetermine

} // end class
