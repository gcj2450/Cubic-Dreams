﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public ParticleSystem clickParticle;

    public new Camera camera;

   

    // Update is called once per frame
    private void Update()
    {
        HandleMoveToPoint();
    }

    private void HandleMoveToPoint()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
                if (navMeshAgent.CalculatePath(hit.point, new NavMeshPath()))
                    MoveToPoint(hit);
        }
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    private void MoveToPoint(RaycastHit hit)
    {
        navMeshAgent.SetDestination(hit.point);
        MakeClickAnimation(hit);
    }

    private void MakeClickAnimation(RaycastHit hit)
    {
        clickParticle.transform.position = hit.point + new Vector3(0, 0.001f, 0);
        clickParticle.Play();
    }
}