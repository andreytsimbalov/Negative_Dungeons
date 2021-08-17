using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {

	private Camera camera;

	public Vector3 offset;
	public Vector3 startPos;
	public Vector3 shackOffset;

	private float timerfpsmax=1f;

	private Vector3 last_pos;// = new Vector3(0,0,0);

	
	private void Start()
	{
		startPos = transform.position;
		shackOffset = Vector3.zero;
		camera = GetComponent<Camera>();
	}


	public void ShackCamera(int max_i=2, float max_time = 0.1f, float magtinude = 0.01f) // 2, 0.1f, 0.1f
	{
		StartCoroutine(ShackCameraCor(max_i, max_time, magtinude));
	}


	IEnumerator ShackCameraCor(int max_i, float max_time, float magtinude)
	{
		for (int i = 0; i < max_i; i++)
		{
			shackOffset = new Vector3(Random.Range(-magtinude, magtinude), Random.Range(-magtinude, magtinude), 0);
			transform.position = startPos + shackOffset;
			yield return new WaitForSeconds(max_time/ max_i);
		}
		shackOffset = Vector3.zero;
		transform.position = startPos + shackOffset;

	}

}
