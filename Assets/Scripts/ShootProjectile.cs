using System;
using Unity.Mathematics;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 3f;
    [SerializeField] private GameObject laserPrefab;
    
    private float cooldownCounter = 0f;

    private void Start()
    {
        ShipAbility.OnCooldownTimeAbility += HandleCooldownTimeEvent;
    }

    void Update()
    {
        Shoot();
    }
    
    void Shoot() { 
        cooldownCounter += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;
        }
    }

    private void HandleCooldownTimeEvent(float i)
    {
        cooldownTime -= math.abs(i);
    }
}
