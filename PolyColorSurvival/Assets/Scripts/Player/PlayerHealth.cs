using Assets.Scripts.MainManagers;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            GameManager.PlayerDied();
            Destroy(gameObject);
        }
    }
}
