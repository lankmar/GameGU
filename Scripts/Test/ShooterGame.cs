﻿using UnityEngine;

namespace ShooterGame
{
    public class Geekbrains : MonoBehaviour
    {
	    [SerializeField] private bool _isAllowScaling;
      private void OnDrawGizmos()
	  {
		Gizmos.DrawIcon(transform.position, "bot.jpg", _isAllowScaling);
	  } 

    }
}
