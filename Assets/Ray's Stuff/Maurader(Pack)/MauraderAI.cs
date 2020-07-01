using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MauraderAI : MonoBehaviour
{
    public float basicSpeed = 1; //speed used for moving 
    public float chaseSpeed = 1; //speed when chasing player
    public float attackDMG  = 1;
    
    
    public float detectionRange = 10;
    public float attackRange = 10;

    public enum MauraderStates {IDLE, WANDER, CHASE, ATTACK, DIE}
    public MauraderStates currentState;

    private float currenthealth;
    private GameObject Player;
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;
    private Health health;

    //Wandering Objects
    private float stopRange = 5;
    public GameObject[] wayPoints;
    private int wayPointCount =0;

    Ray ray;
    RaycastHit hitInfo;
    
    //Attack Variables
    private float attackSpeed = 2;
    private float attackCD = 0;
    public GameObject attackhitbox;

    //Animation variables
    private Animator animator;

    //AI Classes

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        animator = GetComponentInChildren<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (Player == null)
        {
            print("Unable to find Player tag in scene, Please Assign player tag to an object.");

        }
        currenthealth = health.currenthealth;
    }

    // Update is called once per frame
    void Update()
    {


        switch (currentState)
        {

            case MauraderStates.IDLE:
                Idle();
                break;
            case MauraderStates.WANDER:
                Wander();
                break;
            case MauraderStates.CHASE:
                Chase();
                break;
            case MauraderStates.ATTACK:
                Attack();
                break;
            case MauraderStates.DIE:
                Die();
                break;



        }

        if (health.currenthealth <= 0)
        {
            currentState= MauraderStates.DIE;

        }
        if (currenthealth < health.currenthealth)
        {
            currentState = MauraderStates.CHASE;

        }


    }

    private void Idle()
    {
        animator.SetFloat("Speed", 0f);

        if (wayPoints.Length <= 0)
        {
            currentState = MauraderStates.IDLE;
            print("Unable to find waypoints on this entity: " + this.name);

        }
        else
        {
            animator.SetFloat("Speed", 1f);
            navMeshAgent.speed = 3;
            navMeshAgent.SetDestination(wayPoints[wayPointCount].transform.position);
            currentState = MauraderStates.WANDER;
            
        }
    }


    void Wander()
    {
        navMeshAgent.speed = 3.5f;
        animator.SetFloat("Speed", 1f);
        navMeshAgent.SetDestination(wayPoints[wayPointCount].transform.position);
        if (wayPoints.Length <= 0)
        {
            currentState = MauraderStates.IDLE;
            print("Unable to find waypoints on this entity: " + this.name);

        }
        else
        {
            float distance;
           
            distance = Vector3.Distance(wayPoints[wayPointCount].transform.position, transform.position);
            if (distance <= stopRange)
            {
                if (wayPointCount  >= wayPoints.Length-1)
                {
                    wayPointCount = 0;

                    //Make Waypoints
                    navMeshAgent.SetDestination(wayPoints[wayPointCount].transform.position);


                }
                else
                {
                   
                    navMeshAgent.SetDestination(wayPoints[wayPointCount].transform.position);
                    wayPointCount += 1;
                }


            }


        }
        



       
        ray = new Ray(transform.position, //start
            transform.forward);//direction

        if (Physics.Raycast(ray, out hitInfo, detectionRange))
        {
            if (hitInfo.collider.tag == "Player")
            {

                currentState = MauraderStates.CHASE;
            }

        }
        

        ray = new Ray(transform.position, //start
            transform.forward + transform.right);//direction

        if (Physics.Raycast(ray, out hitInfo, detectionRange))
        {
            if (hitInfo.collider.tag == "Player")
            {

                currentState = MauraderStates.CHASE;
            }

        }

        ray = new Ray(transform.position, //start
         transform.forward - transform.right);//direction

        if (Physics.Raycast(ray, out hitInfo, detectionRange))
        {
            if (hitInfo.collider.tag == "Player")
            {

                currentState = MauraderStates.CHASE;
            }

        }


        Vector3 sideangle = new Vector3(0.5f, 0, 0);

        ray = new Ray(transform.position, //start
         transform.forward + sideangle);//direction

        if (Physics.Raycast(ray, out hitInfo, detectionRange))
        {
            if (hitInfo.collider.tag == "Player")
            {

                currentState = MauraderStates.CHASE;
            }

        }


       

        ray = new Ray(transform.position, //start
         transform.forward - sideangle);//direction

        if (Physics.Raycast(ray, out hitInfo, detectionRange))
        {
            if (hitInfo.collider.tag == "Player")
            {

                currentState = MauraderStates.CHASE;
            }

        }
    }


    private void Chase()
    {
        navMeshAgent.speed = 5;
        animator.SetFloat("Speed", 2f);
        if (Vector3.Distance(Player.transform.position, transform.position) < attackRange)
        {
            currentState = MauraderStates.ATTACK;
            navMeshAgent.isStopped = true;
            navMeshAgent.speed = 5;
        }
        else
        {
            navMeshAgent.SetDestination(Player.transform.position);

        }
     
    }

 


    private void Attack()
    {
        animator.SetFloat("Speed", 0);
        if (Vector3.Distance(Player.transform.position, transform.position) > attackRange)
        {
            currentState = MauraderStates.CHASE;
            navMeshAgent.isStopped = false;
        }
        else
        {

            attackCD += Time.deltaTime;
            if (attackCD > attackSpeed)
            {
                animator.SetTrigger("Attack");
             GameObject hitbox   =  Instantiate(attackhitbox, transform);
             Destroy(hitbox, 0.2f);
             attackCD = 0;

            }
        }
        transform.LookAt(Player.transform);
        

    }




    private void Die()
    {
        animator.SetTrigger("Die");
        navMeshAgent.isStopped = true;
        Destroy(this.gameObject, 5f);

    }



    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * detectionRange;
        Gizmos.DrawRay(transform.position, direction);

        
        
        direction = transform.TransformDirection(Vector3.forward + Vector3.right) * detectionRange;
        Gizmos.DrawRay(transform.position, direction);

        direction = transform.TransformDirection(Vector3.forward + Vector3.left) * detectionRange;
        Gizmos.DrawRay(transform.position, direction);

        Vector3 sideangle = new Vector3(0.5f, 0, 0);
        

        direction = transform.TransformDirection(Vector3.forward + sideangle) * detectionRange;
        Gizmos.DrawRay(transform.position, direction);
        
        direction = transform.TransformDirection(Vector3.forward - sideangle) * detectionRange;
        Gizmos.DrawRay(transform.position, direction);


    }



}
