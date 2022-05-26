using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public void Seeker(Transform _target) {
        target = _target;
    }

    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget() {

        GameObject effectTEMP = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectTEMP, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
