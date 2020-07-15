using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.TextCore;

public class Turret : MonoBehaviour
{
    public Transform head;
    public Transform barrelTransform;
    public LineRenderer aimLineRenderer;
    public Vector3 targetPos;
    public bool followTarget = true;
    public void ShootAtTarget()
    {
        transform.DOPunchRotation(barrelTransform.up * 8, 1.0f);
        aimLineRenderer.enabled = false;
        Invoke("ActivateLineRenderer",0.3f);
        RaycastHit hit;
        if (Physics.Raycast(barrelTransform.position, (targetPos - barrelTransform.position).normalized, out hit, 100))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.CompareTag("Player"))
            {
                hit.transform.gameObject.SetActive(false);
                
            }
        }
    }

    void ActivateLineRenderer()
    {
        aimLineRenderer.enabled = true;
    }
    
    public void AimAtTarget()
    {
        head.LookAt(targetPos);
        aimLineRenderer.SetPosition(0,barrelTransform.position);
        aimLineRenderer.SetPosition(1,targetPos);
    }
}