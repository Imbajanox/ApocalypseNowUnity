using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Items/Weapon")]
	public class Weapon : Item
	{
		public int currentBullets = 30;
		public int magazineBullets = 30;
		public float fireRate = 0.2f;

        

		public SO.Vector3Variable rightHandPosition;
		public SO.Vector3Variable rightHandEulers;
		public GameObject modelPrefab;

		public RuntimeWeapon runtime;

        public AnimationCurve recoilY;
        public AnimationCurve recoilZ;

		public void Init()
		{
			runtime = new RuntimeWeapon();
			runtime.modelInstance = Instantiate(modelPrefab) as GameObject;
			runtime.weaponHook = runtime.modelInstance.GetComponent<WeaponHook>();
			runtime.weaponHook.Init();
			
		}

		public class RuntimeWeapon
		{
			public GameObject modelInstance;
			public WeaponHook weaponHook;

		}
	}
}
