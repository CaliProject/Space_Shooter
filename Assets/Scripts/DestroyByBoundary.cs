using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
    // Once the colliders exit the area
    // 一旦物体离开区域
	void OnTriggerExit(Collider other)
	{
        // Destroy the other object
        // 摧毁离开的物体
		Destroy(other.gameObject);
	}
}
