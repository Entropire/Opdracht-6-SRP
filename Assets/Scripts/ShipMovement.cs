using System;
using Unity.Mathematics;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 25f;

    private void Start()
    {
        ShipAbility.OnRotationSpeedAbility += HandleRotationSpeedEvent;
        ShipAbility.OnMovementSpeedAbility += HandleMovementSpeedEvent;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
    }

    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
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