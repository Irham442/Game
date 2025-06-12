using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 3f;
    public float stopDistance = 2f;

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > stopDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }
}
