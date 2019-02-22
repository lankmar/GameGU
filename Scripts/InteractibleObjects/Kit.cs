using UnityEngine;

namespace ShooterGame
{
    public class Kit : Health
    {
       // [SerializeField] private float radius;
        [SerializeField] private int force = 30;


        public int Force { get => force; set => force = value; }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player"))
            {
                GameObject go = other.gameObject;
                Character _char = go.GetComponent<Character>();
                _char.IncrementHealth(Force);
                Destroy(gameObject);
            }
        }
    }
}