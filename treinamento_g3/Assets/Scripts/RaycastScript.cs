﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastScript : MonoBehaviour {

    public GameObject Enemy;
    public GameObject VisionReference;
    private NavMeshAgent Agent;

	void Start () {
        Agent = Enemy.GetComponent<NavMeshAgent>();
        gameObject.GetComponent<Light>().range = Enemy.GetComponent<EnemyAttack>().VisionRange;
    }
	
	void Update () {
        Vector3 Look;
        Look = new Vector3(Agent.destination.x, 0f, Agent.destination.z);
        gameObject.transform.LookAt(Look + new Vector3(Agent.velocity.x * 10,0f, Agent.velocity.z * 10));


        Vector3 Rotatation;
        Vector3 Direction;

        for(float i = 0; i < 30; i = i + 3f)
        {
            Rotatation = new Vector3(0f, i - 15f, 0f);

            Direction = Quaternion.Euler(Rotatation) * gameObject.transform.forward;
            RaycastHit Hit;

            if (Physics.Raycast(Enemy.transform.position, Direction, out Hit, Enemy.GetComponent<EnemyAttack>().VisionRange))
            {
                //Debug.DrawLine(gameObject.transform.position, Hit.point,Color.red,0.5f);
                if (Hit.collider.gameObject.tag == "Player")
                {
                    Enemy.GetComponent<EnemyController>().DetectedPlayer = true;
                }
                else
                {
                    Enemy.GetComponent<EnemyController>().DetectedPlayer = false;
                }

            }
        }
    }
}