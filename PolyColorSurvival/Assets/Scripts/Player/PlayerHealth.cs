using Assets.Scripts.MainManagers;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public Animator damageAnimator;

    public void Damage(float damage)
    {
        health -= damage;
        damageAnimator.SetTrigger("TakeDamage");
        if(health <= 0f)
        {
            GameManager.PlayerDied();
            Destroy(gameObject);
        }
    }
}
