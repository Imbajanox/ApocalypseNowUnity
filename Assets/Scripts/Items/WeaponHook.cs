using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHook : MonoBehaviour {

	public Transform leftHandIK;

    [HideInInspector]
    public float lastFired;

    ParticleSystem[] particles;
	AudioSource audioSource;

	public void Init()
	{	
		GameObject go = new GameObject();
		go.name = "audio holder";
		go.transform.parent = this.transform;
		audioSource = go.AddComponent<AudioSource>();
		audioSource.spatialBlend = 1;
        lastFired = 0;
		particles = GetComponentsInChildren<ParticleSystem>();

	}

	public void Shoot()
	{
		if (particles != null)
		{
			for (int i = 0; i < particles.Length; i++)
			{
				particles[i].Play();
			}
		}
	}


}
