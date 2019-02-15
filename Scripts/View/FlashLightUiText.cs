using UnityEngine;
using UnityEngine.UI;

namespace ShooterGame
{
	public class FlashLightUiText : MonoBehaviour
	{
        private Image _image;

        private void Start()
        {
            //_text = GetComponent<Text>();
            _image = GetComponent<Image>();
        }

        public float Image
        {
            set => _image.fillAmount = value/10; //да это магическое число :)
        }

        public void SetActive(bool value)
        {
            _image.gameObject.SetActive(value);
        }


        //public float Text
        //{
        //	set => _text.text = $"{value:0.0}";
        //}

        //public void SetActive(bool value)
        //{
        //	_text.gameObject.SetActive(value);
        //}
    }
}