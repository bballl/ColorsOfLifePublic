using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.NavMeshComponents
{
    public class ClickToMove : MonoBehaviour
    { 
        private Vector2 target;
        private UnityEngine.AI.NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = true;
            agent.updatePosition = true;   
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetAgentPosition();
            }
        }

        private void SetAgentPosition()
        {
            target = Camera.main.ScreenToWorldPoint(InputController.GetLeftMouseButton());
            agent.SetDestination(target);
        }
    }
}
