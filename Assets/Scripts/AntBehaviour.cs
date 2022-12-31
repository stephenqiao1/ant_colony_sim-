    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehaviour : MonoBehaviour
{
    public float wanderStrength = 1;
    public float maxSpeed = 2;
    public float rotationStrength = 2;
    private float viewRadius = 2.0f;
    private bool isTargeted = false;
    private Transform targetedFood;
    private bool maxFoodReached = false;

    Vector2 position;
    Vector2 direction;
    Vector2 currentVelocity;

    void Start() {
        
    }
    
    void Update()
    {   
        // check if the ant is holding a food item
        if (!maxFoodReached) {
            HandleFood(transform);
        }

        if (!isTargeted) {
            // Generate random direction
            direction = (direction + Random.insideUnitCircle * wanderStrength).normalized;
        }

        Vector2 desiredVelocity = direction * maxSpeed;
        Vector2 desiredRotationForce = (desiredVelocity - currentVelocity) * rotationStrength;
        Vector2 acceleration = Vector2.ClampMagnitude(desiredRotationForce, rotationStrength) / 1;

        // Updated velocity and position of the ant
        currentVelocity = Vector2.ClampMagnitude(currentVelocity + acceleration * Time.deltaTime, maxSpeed);
        position += currentVelocity * Time.deltaTime;

        // Clamp the position of the ant within the camera boundaries
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(position);
        screenPosition.x = Mathf.Clamp(screenPosition.x, 0, Screen.width);
        screenPosition.y = Mathf.Clamp(screenPosition.y, 0, Screen.height);
        position = Camera.main.ScreenToWorldPoint(screenPosition);

        // Direction of the ant's movement
        float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg - 90.0f;

        // Set the position and rotation of the ant
        transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, angle)); 
    }

    void HandleFood(Transform transform) {
        if (!isTargeted) {
            // Get all the food in range 
            Collider2D[] foodInRange = Physics2D.OverlapCircleAll(transform.position, viewRadius, 3);
            if (foodInRange.Length > 0) {
                // select one of the foods in the range at random
                Transform food = foodInRange[Random.Range(0, foodInRange.Length)].transform;
                Vector2 dirToFood = (food.position - transform.position).normalized;

                // target the food
                targetedFood = food;
                isTargeted = true;
            }
        } else {
            // move towards the target food
            direction = (targetedFood.position - transform.position).normalized;

            // pick up the food when close enough
            const float foodPickupRadius = 0.25f;
            if ((targetedFood.position - transform.position).magnitude < foodPickupRadius) {
                // targetedFood.position = transform.position;
                targetedFood.parent = transform;
                isTargeted = false;
                maxFoodReached = true;
            }
        }
    }
}
