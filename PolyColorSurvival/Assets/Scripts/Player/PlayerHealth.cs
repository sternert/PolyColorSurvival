using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
