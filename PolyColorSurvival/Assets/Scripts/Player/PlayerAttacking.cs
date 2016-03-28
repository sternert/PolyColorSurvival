using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAttacking : MonoBehaviour
    {

        private WeaponControl[] _weapons;

        void Awake()
        {
            _weapons = GetComponentsInChildren<WeaponControl>();
        }

        void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                foreach (var weapon in _weapons)
                {
                    if (weapon.CanAttack())
                    {
                        weapon.Attack();
                    }
                }
            }
        }
    }
}
