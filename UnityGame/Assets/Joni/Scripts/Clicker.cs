using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Clicker : MonoBehaviour
{

    private int level = 1;                   //Level-Nr and multiplier for generate Trash
    private int money;                       //collected money
    private int trash;                       //trashcounter for the current level 
    private int trashPerSecond;              //store to display output from helpers
    private bool clicked = true;             //State to break the game for change the scene
    private int baseOfTrashGen = 2;


    private int manhourGrandma = 0;
    private int manhourHippie = 0;
    private int manhourGarbage = 0;
    private int manhourGarbageTruck = 0;
    private int manhourGarbageSuctionMaschine = 0;

    public int trashCollected = 0;

    public int victory_time;                //timer to adjust time betwenn normal levels
    public float boss_victory_time;           //timer to adjust time between boss and normal level

    float time;                             //adding secounds
    public Animator animator;               //To control the trigger

    public List<Helper_Script> helpers;     //list of all Helper_classes

    // ** UI - Elements ** 
    public Button button;                   //area for clicks

    //Informations Text
    public Text timeIndicator;
    public Text moneyIndicator;
    public Text trashIndicator;
    public Text trashPerSecondIndicator;
    public Text levelIndicator;


	//Anbindung an Grafik
	public LevelManager levelManagerScript;

    //DMG Zahlen
    public FloatingTextController ftc;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        button.onClick.AddListener(TaskOnClick);
        trash = newGarbage();
        InvokeRepeating("GenerateNewTrash", 0, 1);
        InvokeRepeating("HelperDoWork", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            CalculateTimeAndUpdateUI();

            if (trash <= 0)
            {
                if(level < 20){
                    NextLevel();
                } else if(level >= 20){
                    SceneManager.LoadScene("StatisticScene", LoadSceneMode.Single);
                }

            }
        }
    }

    //Prepare next level
    void NextLevel(){
        clicked = false;
        level++;
        if (level % 5 == 0)         //each 5th level come a boss level
        {
            trash = (int)(Math.Pow(baseOfTrashGen, level + 2)*5);  //create new trash for next levele
            trashIndicator.text = trash.ToString();
            animator.SetTrigger("Boss_Victory");
            Invoke("ReturnToClicker", boss_victory_time);
        }
        else
        {
            trash = (int)(Math.Pow(baseOfTrashGen, level + 2));  //create new trash for next levele
            animator.SetTrigger("Victory");
            Invoke("ReturnToClicker", victory_time);
        }
        levelManagerScript.setLevel (level);
    }

    //All Helper will be calculated and get influence on the money and trash
    void HelperDoWork(){
        if(clicked){
            int trashPerSecond = 0;
            int trashFromGrandma = 0;
            int trashFromHippie = 0;
            int trashFromGarbage = 0;
            int trashFromGarbageTruck = 0;
            int trashFromGarbageSuctionMaschine = 0;
            foreach(Helper_Script helper in helpers){


                if(helper.helperName.Equals("Alte Oma")){
                    trashFromGrandma += helper.CalculateTrashPerSecond();
                    manhourGrandma += trashFromGrandma;
                }
                if (helper.helperName.Equals("Hippie"))
                {
                    trashFromHippie += helper.CalculateTrashPerSecond();
                    manhourHippie += trashFromHippie;
                }
                if (helper.helperName.Equals("Müllfachkraft"))
                {
                    trashFromGarbage += helper.CalculateTrashPerSecond();
                    manhourGarbage += trashFromGarbage;
                }
                if (helper.helperName.Equals("Müllwagen"))
                {
                    trashFromGarbageTruck += helper.CalculateTrashPerSecond();
                    manhourGarbageTruck += trashFromGarbageTruck;
                }
                if (helper.helperName.Equals("Müllabsauganlage"))
                {
                    trashFromGarbageSuctionMaschine += helper.CalculateTrashPerSecond();
                    manhourGarbageSuctionMaschine += trashFromGarbageSuctionMaschine;
                }


            }

            trashPerSecond = trashFromGrandma + trashFromHippie + trashFromGarbage + trashFromGarbageTruck + trashFromGarbageSuctionMaschine;
            this.trashPerSecond = trashPerSecond;
            trash -= trashPerSecond;
            money += trashPerSecond;
        }
    }


    //Logic from a click on the main-Button
    void TaskOnClick(){
        if(clicked){

            int clickDMG = (int)Math.Ceiling(newGarbage() / 200.0);
            levelManagerScript.HandleClick ();
            ftc.CreateFloatingText(clickDMG.ToString(), transform);

            trashCollected += clickDMG;
            trash -= clickDMG;
            money += clickDMG;
        }
    }

    //InvokeRepeating Method
    //Generate new trash
    void GenerateNewTrash()
    {
        if(clicked) trash += (int)(Math.Pow(baseOfTrashGen, level - 2));
    }

    //Method to invoke after few seconds
    //Change state to clicker and make the button clicked
    void ReturnToClicker()
    {
        clicked = true;
        animator.SetTrigger("Animation_Ended");
    }

    //Calculate new number of garbage on base of 2
    int newGarbage(){
        return (int)Math.Pow(baseOfTrashGen, level + 2);
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
        if (trash < 0) trashIndicator.text = 0.ToString();
        else trashIndicator.text = trash.ToString();
        levelIndicator.text = level.ToString();
    }

    //Buy a helper
    public void Pay(int price){
        money -= price;
        moneyIndicator.text = money.ToString();
    }




    // ** Getter and Setter **

    public int GetMoney(){
        return money;
    }

    public int GetHelperTrash(){
        return manhourGrandma + manhourHippie + manhourGarbage + manhourGarbageTruck + manhourGarbageSuctionMaschine;
    }

    public void SetLevel(int level){

    }

    public void SetMoney(int money){

    }

    public void Cheat(){
        this.level = 20;
        foreach(Helper_Script helper in helpers){
            helper.count = 60;
        }

    }
}
