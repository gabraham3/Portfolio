using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    // Start is called before the first frame update    
    [SerializeField]
    private InputField diceAmt;
    [SerializeField]
    private InputField diceType;
    [SerializeField]
    private InputField Modifier;
    [SerializeField]
    private Text Value;


    private int Amt; //amount of dice in integer form
    private int Type; //Dice type i.e. face on dice in integer form
    private int Mod; //Dice Modifier in integer form
    
    void Start()
    {
        UpdateValues();
    }

    //updates to values in input fields
    public void UpdateValues()
    {
        
        //update Amt
        if (int.TryParse(diceAmt.text, out int result))
        {
            if (result >= 1){
                Amt = result;
            }
            else{
                Amt = 1;
            }
        }
        else
        {
            Amt = 1;
        }

        //update Type
        if (int.TryParse(diceType.text, out result))
        {
            if (result >= 1){
                Type = result;
            }
            else{
                Type = 1;
            }        
        }
        else
        {
            Type = 20;
        }


        //updates the modifier for the dice roll
        if (int.TryParse(Modifier.text, out result))
        {
            Mod = result;
        }
        else
        {
            Mod = 0;
        }
    }


    //function fucntion will be called when dice are rolled
    public int Roll()
    {
        UpdateValues();
        int sum = 0;
        //TODO: add a loop to go Amt times
        for(int i = 0; i < Amt; i++){
            sum = sum + Random.Range(1, Type+1);  
        }
            //TODO: each iteration of loop should roll between 1 and Type

        //TODO: at the end add sum by Mod
        Debug.Log(Amt + "+" + Type + "=" + sum);
        sum = sum + Mod;
        return sum;
    }

    //for normal roll of the dice
    public void NormalRoll()
    {
        int roll = Roll();
        Value.text = roll.ToString();

    }
    
    //gives advantage for dice roll
    public void Advantage()
    {
        int roll = Roll();
        int temp = Roll();
        if (roll <= temp){
            roll = temp;
        }
        Value.text = roll.ToString();
    }

    // gives disadvtange for dice roll
    public void Disadvantage()
    {
        int roll = Roll();
        int temp = Roll();
        if (roll >= temp){
            roll = temp;
        }
        Value.text = roll.ToString();
    }
}
