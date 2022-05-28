using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 0.5f;
    [HideInInspector]
    public float speed;

    public int health = 100;
    public int worth = 25;
    public GameObject deatheffect;


    private void Start()
    {
        speed = startSpeed;
    }
    public void TakeDMG(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    //public void Slow(float pct) {
       // speed = startSpeed * (1f - pct);
    //}


    void Die()
    {

        GameObject effect = (GameObject)Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.Money += worth;
        Destroy(gameObject);
    }
}
