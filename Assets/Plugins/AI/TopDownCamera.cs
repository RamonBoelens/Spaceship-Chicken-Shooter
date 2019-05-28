using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform[] targets;
    public float margin = 1;
    private Camera camera2;
    private Vector3 velocity;

    public void Awake()
    {
        camera2 = GetComponent<Camera>();
    }

    public void Update()
    {
        // Smoothly move the camera to the position
        var position = GetPerfectPosition();
        position = Vector3.SmoothDamp(transform.position, position, ref velocity, 1);
        transform.position = position;
    }

    private Vector3 GetPerfectPosition()
    {
        // No targets? Return default position
        if (targets.Length == 0) return Vector3.up * 20;

        // Create a box that includes all targets
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (var target in targets)
        {
            bounds.Encapsulate(target.position);
        }
        // Add a margin
        bounds.Expand(margin);

        // Calculate the height based on the size of the bounds
        float heightX = 90F / camera2.fieldOfView * Mathf.Abs(bounds.max.x - bounds.center.x);
        float heightZ = 90F / camera2.fieldOfView * Mathf.Abs(bounds.max.z - bounds.center.z);
        float height = Mathf.Max(heightX, heightZ) + bounds.max.y;

        return new Vector3(bounds.center.x, height, bounds.center.z);
    }
}
