using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorAI : MonoBehaviour {

    public float food_level;
    public float drink_level;
    public float scratch_level;



    public bool alive = true;
    public enum states
    {
        Idle,
        Eat,
        Drink,
        Scratch
    };

    public states current_State = states.Idle;

    // Use this for initialization
    void Start()
    {
        gen_stats();
        Find_lowest_stat();
    }

    private void gen_stats()
    {
        food_level = UnityEngine.Random.Range(0, 100);
        drink_level = UnityEngine.Random.Range(0, 100);
        scratch_level = UnityEngine.Random.Range(0, 100);
    }

    private void Update()
    {
        food_level -= 1 * Time.deltaTime;
        drink_level -= 1 * Time.deltaTime;
        scratch_level -= 1 * Time.deltaTime;
    }



    //finds lowest need value need to see if I can change to a switch statement
    public void Find_lowest_stat()
    {
        if (Mathf.Min(food_level, drink_level, scratch_level) == food_level)
        {
            print("Im hungry");
            current_State = states.Eat;
            Eat_State();
        }
        else if (Mathf.Min(food_level, drink_level, scratch_level) == drink_level)
        {
            print("Im thirsty");
            current_State = states.Drink;
            Drink_State();
        }
        else if (Mathf.Min(food_level, drink_level, scratch_level) == scratch_level)
        {
            print("I gotta scratch something");
            current_State = states.Scratch;
            Scratch_State();
        }
        else
        {
            print(Mathf.Min(food_level,drink_level,scratch_level));
            print("couldnt get the lowest stat to match anything");
            current_State = states.Idle;
            Idle_state();
        }
    }




    IEnumerator AI_Update()
    {
        while (alive)
        {
            if (current_State == states.Idle)
            {
                Idle_state();
            }
            else if (current_State == states.Eat)
            {
                Eat_State();
            }
            else if (current_State == states.Scratch)
            {
                Scratch_State();
            }
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForEndOfFrame();
    }

    private void Scratch_State()
    {
        if (current_State == states.Scratch)
        {
            print("im scratching");
        }
    }

    public void Drink_State()
    {
        if (current_State == states.Drink)
        {
            print("im drinking");
        }
    }

    public void Idle_state()
    {
        if (current_State == states.Idle)
        {
            print("im idling");
        }
    }

    public void Eat_State()
    {
        if (current_State == states.Eat)
        {
            print("im eating");

            //eat logic here.....
            //walk to food


            //run co-routine to eat food

            //stand up




            ///then run check for next state
            Find_lowest_stat();
        }
    }
}
