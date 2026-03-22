using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smooth = 3f;

    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
    }
}