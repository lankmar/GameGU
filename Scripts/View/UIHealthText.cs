using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShooterGame
{
    public class UIHealthText : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private int curentHealth;
        Character character;



        private void Start()
        {
            _text = GetComponent<Text>();
            curentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().CurrentHealth;
            character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        }


        public void ShowHealth()
        {
            _text.text = $"{curentHealth}";
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }

        private void Update()
        {
            if (Time.frameCount % 3 == 0)
            {
                FindCurrentHealth();
                _text.text = $"{curentHealth}";
                Debug.Log(curentHealth);
            }
        }

        private void FindCurrentHealth()
        {
            curentHealth = character.CurrentHealth;
        }
    }

}
