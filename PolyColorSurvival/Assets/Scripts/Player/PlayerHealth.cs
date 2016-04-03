using Assets.Scripts.MainManagers;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public Animator damageAnimator;
    public GameManager gameManager;

    private float _startHealth;

    void Awake()
    {
        _startHealth = health;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            gameManager.PlayerDied();
            health = _startHealth;
        }
        else
        {
            damageAnimator.SetTrigger("TakeDamage");
        }
    }
}
