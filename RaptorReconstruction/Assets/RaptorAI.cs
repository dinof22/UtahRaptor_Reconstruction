using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaptorAI : MonoBehaviour {


    public states current_State = states.Idle;
    public NavMeshAgent raptorAgent;
    bool arrived;
    public Transform player_Position;

    public float food_level;
    public float drink_level;
    public float scratch_level;
    public float curiosity_level;

    public List<Transform> wayPointList;



    public bool alive = true;
    public enum states
    {
        Idle,
        Eat,
        Drink,
        Scratch
    };



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
        curiosity_level = UnityEngine.Random.Range(0, 100);
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


    public void Idle_state()
    {
        if (current_State == states.Idle)
        {
            print("im idling");
        }
    }


    //keep the states here in the order the transforms are set in the waypoint list (for simplicity)

    private void Scratch_State()
    {
        if (current_State == states.Scratch)
        {
            print("im scratching");
            raptorAgent.SetDestination(wayPointList[0].position);   // put transform list number in wayPointList
            scratch_level = 100;
        }
    }


    public void Eat_State()
    {
        if (current_State == states.Eat)
        {
            print("im eating");
            raptorAgent.SetDestination(wayPointList[1].position);   // put transform list number in wayPointList
            food_level = 100;

            //eat logic here.....
            //walk to food


            //run co-routine to eat food

            //stand up




            ///then run check for next state
            //Find_lowest_stat();
        }
    }

    public void Drink_State()
    {
        if (current_State == states.Drink)
        {
            print("im drinking");
            raptorAgent.SetDestination(wayPointList[2].position);   // put transform list number in wayPointList
            drink_level = 100;
        }
    }

    public void Summon_State()
    {
        print("Im going to the player");
        raptorAgent.SetDestination(player_Position.position);

    }


}
