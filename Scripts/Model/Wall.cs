using UnityEngine;

namespace ShooterGame
{
	public class Wall : BaseObjectScene, ISelectObj, IHealth
    {
		[SerializeField] private BulletProjector _projector; // manager

        public int MaxHealth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int CurrentHealth => throw new System.NotImplementedException();

        public bool Regeneration { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public void SetDamage(InfoCollision info)
		{
			if (_projector == null) return;
			var projectorRotation = Quaternion.FromToRotation(-Vector3.forward, info.Contact.normal);
			var obj = Instantiate(_projector, info.Contact.point + info.Contact.normal * 0.25f, projectorRotation, info.ObjCollision); // manager
			obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
		}

		[SerializeField] private KeyCode _keyCode = KeyCode.A;

        public string GetMessage()
		{
			return Name;
		}

		public KeyCode GetKeyCode()
		{
			return _keyCode;
		}
	}
}