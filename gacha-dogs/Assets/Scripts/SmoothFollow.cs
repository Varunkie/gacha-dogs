using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    public float yOffset = 4f;
    public bool yFixed = true;
    public UpdateMode updateMode = UpdateMode.Update;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (updateMode == UpdateMode.Update)
            Follow();
    }

    private void LateUpdate()
    {
        if (updateMode == UpdateMode.LateUpdate)
            Follow();
    }

    private void Follow()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.position;
        targetPosition.z = -10f;
        targetPosition.y += yOffset;
        if (yFixed) targetPosition.y = transform.position.y;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public enum UpdateMode
    {
        Update,
        LateUpdate
    }
}