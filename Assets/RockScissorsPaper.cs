using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScissorsPaper : MonoBehaviour
{
    //response strings, also animation trigger names
    public string[] response = new string[3] { "trigScissors", "trigPaper", "trigRock" };
    public RockScissorsPaper opponent; //the other NPC

    public bool fight;  //one NPC picks the fight

    private const int SCISSORS = 0;
    private const int PAPER = 1;
    private const int ROCK = 2;

    const int WIN = 0;
    const int LOSE = 1;
    const int DRAW = 2;


    public int Wins = 0;
    public int Losses = 0;
    public int Draws = 0;

    public Animator animator;

    public void DoAnimTrigger()
    {

        Debug.Log("DO ANIM TRIGGER STUFF ");
       

    }
    // Update is called once per frame
    void Update()
    {
        
        if(fight)
        {
            int me = Fight();
            int him = opponent.Fight(); //sorry for the sexist assumption

            Evaluate(me, him);

            fight = false;
        }
    }
    public int Fight()
    {
        
        return Random.Range(0, 3);
       
    }
    void Evaluate(int me, int him)
    {
        string[] winlose = new string[3] { " I win", " I lose", "We tie" };

        

        int play = -1;  //default to error



        //scissors beats paper, etc...
        if (me == SCISSORS && him == PAPER)
        {
            play = WIN;
        }

        if (me == PAPER && him == ROCK)
        {

            play = WIN;

        }
        if (me == ROCK && him == SCISSORS)
        {
            play = WIN;
        }
        if (me == PAPER && him == SCISSORS)
        {
            play = LOSE;
        }
        if (me == SCISSORS && him == ROCK)
        {
            play = LOSE;
        }
        if (me == ROCK && him == PAPER)
        {
            play = LOSE;
        }
        if (me == him)
        {
            play = DRAW;

        }

        if (play == WIN)
        {
            Wins++;
            opponent.Losses++;
        }

        if (play == LOSE)
        {
            Losses++;
            opponent.Wins++;
        }
        if (play == DRAW)
        {
            Draws++;
            opponent.Draws++;

        }

        Debug.Log("me " + response[me] + " vs. him " + response[him] + " -> " + winlose[play]);

        //trigger animations after resolution
        doAnimations(me, him, play);
    }
    void doAnimations(int me, int him, int result)
    {
        //clear all current trigs and bools
        animator.ResetTrigger("trigScissors");
        animator.ResetTrigger("trigPaper");
        animator.ResetTrigger("trigRock");
        animator.SetBool("doVictory", false);
        animator.SetBool("doFalldown", false);
        animator.SetBool("doDraw", false);


        opponent.animator.ResetTrigger("trigScissors");
        opponent.animator.ResetTrigger("trigPaper");
        opponent.animator.ResetTrigger("trigRock");
        opponent.animator.SetBool("doVictory", false);
        opponent.animator.SetBool("doFalldown", false);
        opponent.animator.SetBool("doDraw", false);



        if (result == WIN)
        {
            //I win
            animator.SetBool("doVictory", true);
            opponent.animator.SetBool("doFalldown", true);


        }
        if (result == LOSE)
        {
            //I lose
            animator.SetBool("doFalldown", true);
            opponent.animator.SetBool("doVictory", true);

        }
        if (result == DRAW)
        {
            //we draw
            animator.SetBool("doDraw", true);
            opponent.animator.SetBool("doDraw", true);

        }

        //fire triggers, after which the results will play
        animator.SetTrigger(response[me]);
        opponent.animator.SetTrigger(response[him]);


    }

}
