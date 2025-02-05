using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lazers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 1000f;

    // state of the weapon
    bool isFiring = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
        MoveCrossHair();
        MoveTargetPoint();
        AimLazers();
    }


    private void ProcessFiring()
    {
        foreach (var weapon in lazers)
        {
            var emmissionModule = weapon.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }

    public void OnFire(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }

    void MoveCrossHair()
    {
        crosshair.position = Input.mousePosition;
    }
    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    // Aim the target with direction if fireDirection --> have angle --> change Rotation
    void AimLazers()
    {
        foreach (GameObject lazer in lazers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            lazer.transform.rotation = rotationToTarget;
        }
    }
}
