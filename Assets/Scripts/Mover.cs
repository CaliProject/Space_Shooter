using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	void Start()
	{
        // On start, set the object moving forward (backward if the speed is negative)
        // 开始时，设置物体向前移动（如果速度为负则向后）
        rigidbody.velocity = transform.forward * speed;
	}
}
