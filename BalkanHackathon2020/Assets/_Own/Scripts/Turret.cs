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

    public void ShootAt(Vector3 targetPos)
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
    
    public void AimAt(Vector3 pos)
    {
        head.LookAt(pos);
        aimLineRenderer.SetPosition(0,barrelTransform.position);
        aimLineRenderer.SetPosition(1,pos);
    }
}