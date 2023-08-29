using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
            MoveToTargetPosition();
        }
    }

    private void SetTargetPosition()
    {
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float rayDistance))
        {
            targetPosition = ray.GetPoint(rayDistance);
        }
    }

    private void MoveToTargetPosition()
    {
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 moveDirection = targetPosition - transform.position;
            float moveSpeed = 5f; // Adjust this value to control the movement speed

            if (moveDirection.magnitude > 0.1f)
            {
                transform.position += moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
