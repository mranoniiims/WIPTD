using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public int health = 100;
    public int value = 25;
    public GameObject deatheffect;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDMG(int amount) {
        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    void Die() {

        GameObject effect = (GameObject)Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.Money += value;
        Destroy(gameObject);
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
                EndPath();
                return;
            }

            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }

        void EndPath() {
            PlayerStats.Lives--;
            Destroy(gameObject);
        }
    
    }
}
