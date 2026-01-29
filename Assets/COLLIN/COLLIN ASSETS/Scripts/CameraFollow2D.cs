using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;         // Player to follow
    public float smoothSpeed = 0.125f;
    public float fixedY = 0f;        // Y position to lock the camera at
    public Vector3 offset;           // Offset from the player (Z should be -10)

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(
            target.position.x + offset.x,
            fixedY,                      // Lock Y
            offset.z                     // Keep Z (usually -10 for 2D)
        );

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
