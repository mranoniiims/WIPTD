using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.5f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.02f) {
            GetNextWaypoint();
        }

        void GetNextWaypoint() {

            if (wavepointIndex >= Waypoints.points.Length - 1) {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }
    
    }
}
