	using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpForce;
	public float distToGround;

	public Vector3 spawn;
	public Vector3 currentPosition;

	public int deathCount;

	public GameManager manager;

	public AudioClip[] clips;
	public AudioSource[] sources;
	

	void Start()
	{
		distToGround = collider.bounds.extents.y;
		spawn = transform.position;
		manager = manager.GetComponent<GameManager> ();

		//TAKE NOTES MOTHERFUCKER! THIS IS HOW YOU PLAY MULTIPLE CLIPS/HAVE MULTIPLE AUDIOSOURCES ON A SINGLE GAMEOBJECT!
		sources = new AudioSource[clips.Length];
		int i = 0;
		while (i < clips.Length)
		{
			GameObject child = new GameObject ("Player");
			child.transform.parent = gameObject.transform;
			sources[i] = child.AddComponent("AudioSource") as AudioSource;
			sources[i].clip = clips[i];
			i++;
		}
	}

	bool IsGrounded()
	{
		return Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.1f);
	}

	void FixedUpdate()
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody.velocity = new Vector3(move * maxSpeed, rigidbody.velocity.y, 0);

		Checkpoints ();

		if (transform.position.y < -5)
		{
			Die ();
		}
	}

	void Update()
	{
		//jump
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded ())
		{
			rigidbody.AddForce(new Vector3(0, jumpForce, 0));
			sources[0].Play ();
		}
	}

	void Checkpoints()
	{
		if (transform.position.x > 11.5 && transform.position.x < 30f)
		{
			spawn = new Vector3(10.5f, 1f);
		}

		if (transform.position.x > 37)
		{
			spawn = new Vector3(37.5f, 2.5f);
		}
	}

	void Die()
	{
		transform.position = spawn;
		deathCount++;
		sources [1].Play ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Goal")
		{
			manager.CompleteLevel(deathCount);
		}
	}
}