using UnityEngine;

namespace ShooterGame
{
    class Character: Health, ICharacter
    {
        [SerializeField]
        [Range(1, 50)]
        protected int damageToPain = 15;

        public bool isNPC { get { return true; } }
        public Transform m_Transform { get; protected set; }

        public bool isActive { get { return gameObject.activeSelf; } }


        protected virtual void Awake()
        {
            m_Transform = transform;
        }

        public virtual void Kill()
        {
            if (isAlive)
            {
                currentHealth = 0;
                OnDie();
            }
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public override void TakeDamage(DamageInfo damageInfo)
        {
            base.TakeDamage(damageInfo);
        }

        public override void IncrementHP(int addАmount)
        {
             base.IncrementHP(addАmount);
        }
    }
}