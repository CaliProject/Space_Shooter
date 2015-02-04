using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble;

	void Start()
	{
        // On start, set the rotation speed in random
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
