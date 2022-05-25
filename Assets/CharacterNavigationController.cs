using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigationController : MonoBehaviour
{

    public int movementSpeed = 1;
    public int rotationSpeed = 120;
    public float stopDistance = 2.5f;
    public Vector3 destination;
    public bool reachedDestination;
    Vector3 velocity;
    Vector3 lastPosition;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }

            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);

            //animator.SetFloat("Horiontal",rightDotProduct);
            //animator.SetFloat("Forward",fwdDotProduct);
        }
        else
        {
            reachedDestination = true;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        //this.SetDestination = destination;
        //reachedDestination = false;
    }
}
