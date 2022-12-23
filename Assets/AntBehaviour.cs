using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehaviour : MonoBehaviour
{
    public float speed = 1;
    public float steer = 1;
    public float wander = 1;

    Vector2 currPosition;
    Vector2 currVelocity;
    Vector2 currDirection;
    void Update()
    {
        // Direction of the ant's movement
        currDirection = currDirection + Random.insideUnitCircle * wander;

        // Velocity of the ant = direction * speed 
        Vector2 wantedVelocity = currDirection * speed;
        Vector2 wantedSteering = (wantedVelocity - currVelocity) * steer;
        Vector2 acceleration = Vector2.ClampMagnitude(wantedSteering, steer);

        currVelocity = Vector2.ClampMagnitude(currVelocity + acceleration * Time.deltaTime, speed);
        
        // Updated position of the ant
        currPosition += currVelocity * Time.deltaTime;

        float angle = Mathf.Atan2(currVelocity.y, currVelocity.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(currPosition, Quaternion.Euler(0,0, angle));
    }
}
