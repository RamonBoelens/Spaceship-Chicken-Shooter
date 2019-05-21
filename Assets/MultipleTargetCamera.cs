using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> target;
    public Vector3 offset;

    public float smoothTime = .5f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (target.Count == 0)
            return;

        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    private Vector3 GetCenterPoint()
    {
        if (target.Count == 1)
            return target[0].position;

        var bounds = new Bounds(target[0].position, Vector3.zero);
        for (int i = 0; i < target.Count; i++)
        {
            bounds.Encapsulate(target[i].position);
        }

        return bounds.center;
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(target[0].position, Vector3.zero);
        for (int i = 0; i < target.Count; i++)
        {
            bounds.Encapsulate(target[i].position);
        }

        return bounds.size.x;
    }
}
