using Unity.Mathematics;
using UnityEngine;

public class ShipMovement : Movement
{
    private void Start()
    {
        ShipAbility.OnRotationSpeedAbility += HandleRotationSpeedEvent;
        ShipAbility.OnMovementSpeedAbility += HandleMovementSpeedEvent;
    }

    private void FixedUpdate()
    {
        Move(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));
    }

    private void HandleRotationSpeedEvent(float i)
    {
        rotationSpeed += math.abs(rotationSpeed);
    }

    private void HandleMovementSpeedEvent(float i)
    {
        moveSpeed += math.abs(moveSpeed);
    }
}