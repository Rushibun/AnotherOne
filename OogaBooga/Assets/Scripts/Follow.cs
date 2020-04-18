using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float followDistance;
    public float cameraFollowSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        transform.position = targetPosition + followVector;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector;

        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, cameraFollowSpeed * Time.deltaTime);
        // Lerp = linear interpolation = you're trying to interpolate a point btwn two points
        // y = p1 + (p2 - p1) * t [line eqation], you're trying to find another point inbtwn those points;
        // t = [0~1]; if t = 0, x = p1; if t = 1, x = p2; if 0 < t < 1, x = any point on line
    }
}
