using UnityEngine;

namespace ShooterGame
{
	public interface ISelectObj
	{
		string GetMessage();
		KeyCode GetKeyCode();
	}
}