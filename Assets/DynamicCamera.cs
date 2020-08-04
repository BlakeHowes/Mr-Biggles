using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public Transform GhostCat;

    [SerializeField]
    private float SmoothSpeed;
    public Vector3 offset;
    void FixedUpdate()
    {
        Vector3 Pos1 = GhostCat.position + offset;
        Vector3 Pos2 = Vector3.Lerp(transform.position, Pos1, SmoothSpeed);
        transform.position = Pos2;
        transform.LookAt(GhostCat);
    }
}
