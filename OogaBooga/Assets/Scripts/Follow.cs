using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    
    public GameObject target;
    public float followDistance;
    public Vector3 followOffset;
    public float cameraFollowSpeed = 0.1f;
    public float cameraRotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = CalculateCameraTargetPosition();

        transform.rotation = Quaternion.LookRotation(target.transform.forward);
        // a quaternion is an axis and an angle of rotation around that axes
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraTargetPosition = CalculateCameraTargetPosition();

        transform.position = Vector3.Lerp(transform.position, 
           cameraTargetPosition, cameraFollowSpeed * Time.deltaTime);
        // Lerp = linear interpolation = you're trying to interpolate a point btwn two points
        // y = p1 + (p2 - p1) * t [line eqation], you're trying to find another point inbtwn those points;
        // t = [0~1]; if t = 0, x = p1; if t = 1, x = p2; if 0 < t < 1, x = any point on line

        // which way is capsule facing? --> target.transform.forward
        Vector3 targetForward = target.transform.forward;
        // taking camera direction and slowly rotating capsule toward
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetForward,
           cameraRotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(direction);
    }
    Vector3 CalculateCameraTargetPosition()
    {   
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector + followOffset;

        return cameraTargetPosition;
    }
}
