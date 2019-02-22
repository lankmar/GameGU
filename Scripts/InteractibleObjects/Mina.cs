using System.Collections;
using UnityEngine;

namespace ShooterGame
{
    public class Mina : MonoBehaviour
    {
        public float Radius;
        public float Force;
        [SerializeField]  private float maxIntensity = 10;
        [SerializeField] private GameObject _light;

        private float _timeLight;

        private void Start()
        {
            _light.GetComponent<Light>().color = Color.red;
            _light.GetComponent<Light>().intensity = 0;
          
        }


        private void OnTriggerExit(Collider other)
        {

           // Explosion();
        }

        private void Explosion()
        {
            Debug.Log("Explosion" );
            _light.GetComponent<Light>().intensity = maxIntensity;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);
            StartCoroutine(Light());
            foreach (Collider obj in hitColliders)
            {
                var tempRigidbody = obj.GetComponent<Rigidbody>();
                if (!tempRigidbody) continue;
                tempRigidbody.useGravity = true;
                tempRigidbody.isKinematic = false;
                tempRigidbody.AddExplosionForce(Force, transform.position, Radius, 0.0F);
            }

            Destroy(gameObject, _timeLight);
        }


        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player"))
            {
                GameObject go = other.gameObject;
                Character _char = go.GetComponent<Character>();
                DamageInfo damage = new DamageInfo(20, null, null, EDamageType.Unknown);
                _char.TakeDamage(damage );
                _timeLight = 0.5f;
                Explosion();
            }

        }

        //private void OnDrawGizmosSelected()
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(transform.position, Radius);
        //}

        IEnumerator Light()
        {
            while (true)
            {
                _light.SetActive(!_light.activeSelf);
                yield return new WaitForSeconds(_timeLight);
            }
        }
    }
    }