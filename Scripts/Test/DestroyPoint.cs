﻿using System;
using UnityEngine;

namespace ShooterGame
{
	public class DestroyPoint : MonoBehaviour
	{
		public event Action OnFinishChange;
		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Bot>())
			{
				OnFinishChange?.Invoke();
				Destroy(gameObject);
			}
		}
	}
}