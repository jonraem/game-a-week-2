using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float threshold1;
	public float threshold2;
	public float threshold3;
	public GameObject player;

	void Start()
	{
		SetCameraTransform (3.0f, 1.0f);
	}

	void LateUpdate()
	{
		if (player.transform.position.x > threshold1)
		{
			SetCameraTransform(16.25f, 1.5f);
		}

		if (player.transform.position.x < threshold1 - 3)
		{
			SetCameraTransform(3.0f, 1.0f);
		}

		if (player.transform.position.x > threshold2)
		{
			SetCameraTransform(32f, 3.0f);
		}

		if ((player.transform.position.x < threshold2 - 6) && (player.transform.position.x > threshold1))
		{
			SetCameraTransform(16.25f, 1.5f);
		}

		if (player.transform.position.x > threshold3)
		{
			SetCameraTransform(49f, 2.25f);
		}
		
		if ((player.transform.position.x < 38f) && ((player.transform.position.x > threshold2) && (player.transform.position.x > threshold1)))
		{
			SetCameraTransform(32f, 3.0f);
		}

	}

	void SetCameraTransform(float x, float y)
	{
		transform.position = new Vector3 (x, y, -10f);
	}
}
