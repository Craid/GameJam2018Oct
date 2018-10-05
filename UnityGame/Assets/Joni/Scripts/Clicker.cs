using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clicker : MonoBehaviour
{

    private int level = 1;                   //Level-Nr and multiplier for generate Trash
    private int money;                       //collected money
    private int trash;                       //trashcounter for the current level 
    private bool clicked = true;             //State to break the game for change the scene

    public int victory_time;                //timer to adjust time betwenn normal levels
    public int boss_victory_time;           //timer to adjust time between boss and normal level

    float time;                             //adding secounds
    public Animator animator;               //To control the trigger

    public List<Helper_Script> helper;     //list of all Helper_classes

    // ** UI - Elements ** 
    public Button button;                   //area for clicks

    //Informations Text
    public Text timeIndicator;
    public Text moneyIndicator;
    public Text trashIndicator;
    public Text levelIndicator;

    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
        trash = newGarbage();
        InvokeRepeating("GenerateNewTrash", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            CalculateTimeAndUpdateUI();

            if (trash == 0)
            {
                NextLevel();
            }
        }
    }

    //Prepare next level
    void NextLevel(){
        clicked = false;
        trash = (int)(Math.Pow(2, level + 4));
        if (level % 5 == 0)
        {
            animator.SetTrigger("Boss_Victory");
            Invoke("ReturnToClicker", boss_victory_time);
        }
        else
        {
            animator.SetTrigger("Victory");
            Invoke("ReturnToClicker", victory_time);
        }
        level++;
    }

    //Logic from a click on the main-Button
    void TaskOnClick(){
        if(clicked){
            trash -= 1;
            money += 1;
        }
    }

    //InvokeRepeating Method
    //Generate new trash
    void GenerateNewTrash()
    {
        if(clicked) trash += (int)(Math.Pow(2, level - 2));
    }

    //Method to invoke after few seconds
    //Change state to clicker and make the button clicked
    void ReturnToClicker()
    {
        clicked = true;
        animator.SetTrigger("Clicker");
    }

    //Calculate new number of garbage on base of 2
    int newGarbage(){
        return (int)Math.Pow(2, level + 4);
    }

    // - add deltaTime to timeCounter
    // - update all text of UI-Elements
    void CalculateTimeAndUpdateUI()
    {
        time += Time.deltaTime;
        TimeSpan ts = TimeSpan.FromSeconds(time);
        timeIndicator.text = string.Format("{0}h{1}m{2}s", ts.Hours, ts.Minutes, ts.Seconds);
        moneyIndicator.text = money.ToString();
        trashIndicator.text = trash.ToString();
        levelIndicator.text = level.ToString();
    }
}
