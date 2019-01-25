using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaptorAI : MonoBehaviour {


    public states current_State = states.Idle;
    NavMeshAgent raptorAgent;
    Animator animator;

    public bool arrived;
    public Transform player_Position;

    public float food_level;
    public float drink_level;
    public float scratch_level;
    public float curiosity_level;
    public float idle_level;

    public List<Transform> wayPointList;
    public bool alive = true;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        raptorAgent = GetComponent<NavMeshAgent>();

        InvokeRepeating("pathCompleteCheck", 0, 0.5f);
    }

    public enum states
    {
        Idle,
        Eat,
        Drink,
        Scratch,
        summon,
        lookAtPlayer

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
        idle_level = 100;
    }

    private void Update()
    {
        //animator parameter controller
        animator.SetFloat("Speed", raptorAgent.velocity.magnitude);


        //need timers
        food_level -= 1 * Time.deltaTime;
        drink_level -= 1 * Time.deltaTime;
        scratch_level -= 1 * Time.deltaTime;
        idle_level -= 1.5f * Time.deltaTime;
        curiosity_level -= 1.2f * Time.deltaTime;


    }



    public void pathCompleteCheck()
    {
        if (raptorAgent.pathPending)
        {
            return;
        }
        if (raptorAgent.remainingDistance < raptorAgent.stoppingDistance)
        {
            if (!arrived)
            {
                arrived = true;
                /*
                 * curentState = Stateclass
                 * stateCalss.Startcoroutine
                 */
                switch (current_State)
                {
                    case states.Eat:
                        StartCoroutine("eat_Action");
                        break;
                    case states.Drink:
                        StartCoroutine("drink_Action");
                        break;
                    case states.Scratch:
                        StartCoroutine("scratch_Action");
                        break;
                    case states.Idle:
                        print("path complete check hitting idle");
                        break;
                    case states.lookAtPlayer:
                        StartCoroutine("lookAtPlayer_Action");
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            arrived = false;
        }

    }

    //finds lowest need value need to see if I can change to a switch statement
    public void Find_lowest_stat()
    {
        //temporary variable created that is minimum for all the stat levels
        float minimumStat = Mathf.Min(food_level, drink_level, scratch_level, idle_level, curiosity_level);

        if (minimumStat == food_level)
        {
            print("Im hungry");
            current_State = states.Eat;
            Eat_State();
        }
        else if (minimumStat == drink_level)
        {
            print("Im thirsty");
            current_State = states.Drink;
            Drink_State();
        }
        else if (minimumStat == scratch_level)
        {
            print("I gotta scratch something");
            current_State = states.Scratch;
            Scratch_State();
        }
        else if (minimumStat == idle_level)
        {
            print("I want to idle");
            current_State = states.Idle;
            Idle_state();
        }
        else if (minimumStat == curiosity_level)
        {
            print("I want to look at the player");
            current_State = states.lookAtPlayer;
            lookAtPlayer_state();

        }
        else
        {
            print(minimumStat);
            print("couldnt get the lowest stat to match anything");
            current_State = states.Idle;
            Idle_state();
        }
    }



    /*
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
    */

    public void Idle_state()
    {
        if (current_State == states.Idle)
        {
            raptorAgent.stoppingDistance = 2;
            print("im idling");
            StartCoroutine("idle_Action");
            print("destination is: " + wayPointList[1].position);
        }
    }
    IEnumerator idle_Action()
    {
        print("running idle coroutine");
        idle_level = 100;
        yield return new WaitForSeconds(5f);
        Find_lowest_stat();
    }


    public void lookAtPlayer_state()
    {
        print("im going to look at the player");
        raptorAgent.stoppingDistance = 5;
        raptorAgent.SetDestination(player_Position.position);
    }
    IEnumerator lookAtPlayer_Action()
    {
        curiosity_level = 100;
        print("im looking at the player now");
        yield return new WaitForSeconds(5f);
        print("this guy is boring");
        raptorAgent.stoppingDistance = 2;
        Find_lowest_stat();
    }

    //keep the states here in the order the transforms are set in the waypoint list (for simplicity)
    /// <summary>
    /// ////////////////////////////////////////Scratch State
    /// </summary>
    public void Scratch_State()
    {
        if (current_State == states.Scratch)
        {
            print("im scratching");
            raptorAgent.stoppingDistance = 2;
            raptorAgent.SetDestination(wayPointList[0].position);   // put transform list number in wayPointList
        }
    }
    IEnumerator scratch_Action()
    {
        scratch_level = 100;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0,3));
        animator.SetBool("Eat", true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("Eat", false);
        yield return new WaitForSeconds(3f);
        //animator.SetBool("Eat", false);
        Find_lowest_stat();
    }



    /// <summary>
    /// /////////////////////////////////////////Eat state
    /// </summary>
    public void Eat_State()
    {
        if (current_State == states.Eat)
        {
            print("im eating");
            raptorAgent.stoppingDistance = 2;
            raptorAgent.SetDestination(wayPointList[1].position);   // put transform list number in wayPointList


            //eat logic here.....
            //walk to food


            //run co-routine to eat food

            //stand up




            ///then run check for next state
            //Find_lowest_stat();
        }
    }
    IEnumerator eat_Action()
    {
        food_level = 100;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0, 3));
        animator.SetBool("Eat", true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("Eat", false);
        yield return new WaitForSeconds(3f);
        //animator.SetBool("Eat", false);
        Find_lowest_stat();
    }



    /// <summary>
    /// ///////////////////////////////Drink state
    /// </summary>
    public void Drink_State()
    {
        if (current_State == states.Drink)
        {
            print("im drinking");
            raptorAgent.stoppingDistance = 2;
            raptorAgent.SetDestination(wayPointList[2].position);   // put transform list number in wayPointList

        }
    }
    IEnumerator drink_Action()
    {
        drink_level = 100;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0, 3));
        animator.SetBool("Eat", true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("Eat", false);
        yield return new WaitForSeconds(3f);
        //animator.SetBool("Eat", false);
        Find_lowest_stat();
    }

    /// <summary>
    /// //////////////////////////////////Summon state
    /// </summary>
    public void Summon_State()
    {
        print("the player has summoned me!");
        raptorAgent.SetDestination(player_Position.position);
        raptorAgent.stoppingDistance = 5;

    }

    public void dismiss()
    {
        Find_lowest_stat();
        raptorAgent.stoppingDistance = 2;
    }
}
