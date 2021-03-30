using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечающий за передвижение игрока
/// </summary>
public class Move : MonoBehaviour
{
	[SerializeField]
	float speed = 1.5f;
	
	private Vector3 direction;
	private float h, v;
	private Rigidbody body;
	private float rotationY;

	void Start()
	{
		body = GetComponent<Rigidbody>();
		body.freezeRotation = true;
	}

	void FixedUpdate()
	{
		body.AddForce(direction * speed, ForceMode.VelocityChange);

		if (Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
		}
		if (Mathf.Abs(body.velocity.z) > speed)
		{
			body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
		}
	}

	void Update()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
		rotationY += Input.GetAxis("Mouse Y");
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

		direction = new Vector3(h, 0, v);
		direction = transform.TransformDirection(direction);
		direction = new Vector3(direction.x, 0, direction.z);

	}
}
