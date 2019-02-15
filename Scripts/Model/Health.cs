using System.Collections;
using UnityEngine;

namespace ShooterGame
{
    class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        protected int maxHealth = 100;
        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        [SerializeField]
        protected int currentHealth = 75;
        public int CurrentHealth { get { return currentHealth; } }

        [SerializeField]
        private bool regeneration = false;
        public bool Regeneration
        {
            get { return regeneration; }
            set { regeneration = value; }
        }

        [SerializeField]
        private float regenerationDelay = 2f;
        public float RegDelay
        {
            get { return regenerationDelay; }
            set { regenerationDelay = value; }
        }

        [SerializeField]
        private int regAmount = 1;
        public int RegAmount
        {
            get { return regAmount; }
            set { regAmount = value; }
        }

        [SerializeField]
        private float regInterval = 1.25f;
        public float RegInterval
        {
            get { return regInterval; }
            set { regInterval = value; }
        }

        public bool isAlive { get { return currentHealth > 0; } }

        private int nativeHealth = 0;

        protected virtual void Start()
        {
            nativeHealth = currentHealth;

            if (isAlive && regeneration && currentHealth < maxHealth)
                StartCoroutine("StartRegeneration");
        }

        public void SetDamage(DamageInfo info)
        {
            DecrementHealth(CalcDamage(info.damage));
        }

        public virtual void TakeDamage(DamageInfo damageInfo)
        {

            DecrementHealth(CalcDamage(damageInfo.damage));
        }

        protected int CalcDamage(float damage)
        {
            return Mathf.RoundToInt(damage);
        }

        public virtual bool DecrementHealth(int damage)
        {
            if (isAlive == false || damage <= 0)
                return false;

            currentHealth = Mathf.Max(0, currentHealth -= damage); //Debug.Log( "DecrementHealth! " + damage );

            if (isAlive)
            {
                if (regeneration)
                {
                    StopCoroutine("StartRegeneration");
                    StartCoroutine("StartRegeneration");
                }
            }
            else
            {
                OnDie();
            }

            return true;
        }

        protected virtual void OnRespawn()
        {
            currentHealth = nativeHealth;
        }

        private IEnumerator StartRegeneration()
        {
            if (regenerationDelay > 0f)
                yield return new WaitForSeconds(regenerationDelay);

            float elapsed = 0f;
            bool incremented = true;
            while (incremented)
            {
                elapsed += Time.deltaTime;
                if (elapsed > regInterval)
                {
                    elapsed = 0f;
                    incremented = IncrementHealth(regAmount);
                }

                yield return null;
            }
        }

        protected virtual void OnDie()
        {
            if (regeneration)
                StopCoroutine("StartRegeneration");

            Vector3 nativePos = transform.position;
            nativePos.y += .15f;
        }

        public virtual bool IncrementHealth(int addАmount)
        {
            if ((currentHealth >= maxHealth) || (addАmount <= 0))
                return false;

            currentHealth = Mathf.Min(maxHealth, currentHealth += addАmount);
            return true;
        }
    }

    
}