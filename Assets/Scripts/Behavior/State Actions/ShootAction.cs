using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Shoot Action")]
	public class ShootAction : StateActions
	{
		public override void Execute(StateManager states)
		{
			if (states.isShooting)
			{
				states.isShooting = false;
				Weapon w = states.inventory.currentWeapon;

				if (w.currentBullets > 0)
				{
					
					if (Time.realtimeSinceStartup - w.runtime.weaponHook.lastFired > w.fireRate)
					{
						w.runtime.weaponHook.lastFired = Time.realtimeSinceStartup;

						w.runtime.weaponHook.Shoot();
						states.animHook.RecoilAnim();

						w.currentBullets--;
						if (w.currentBullets < 0)
							w.currentBullets = 0;
					}
				}
			}
		}

	}
}
