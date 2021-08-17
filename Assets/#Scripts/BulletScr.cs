using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    public float start_speed = 15f;
    public float speed = 5f;
    private Rigidbody2D rb;
	public GameObject postBullet;
	public List<string> tags = new List<string>();

	void Start()
    {
		speed = start_speed;
        rb = GetComponent<Rigidbody2D>();

		rb.rotation = transform.rotation.eulerAngles.z;
		rb.velocity = Vec2rot(Vector2.right, transform.rotation.eulerAngles.z) * speed;

		//StartCoroutine(RotateBullet());
		Destroy(gameObject, 3f);
	}

    
	//IEnumerator RotateBullet()
	//{
	//	while (true)
	//	{
	//		rb.rotation -= 180.0f * Time.deltaTime;
	//		yield return new WaitForEndOfFrame();
	//	}
	//}

	Vector2 Vec2rot(Vector2 vec, float angle)
	{
		angle = angle * Mathf.PI / 180f;
		Vector2 res = Vector2.zero;
		res.x = vec.x * Mathf.Cos(angle) - vec.y * Mathf.Sin(angle);
		res.y = vec.x * Mathf.Sin(angle) + vec.y * Mathf.Cos(angle);


		return res;
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if(tags.Contains(coll.tag))
		{
			if (coll.tag == "Number")
				coll.GetComponent<Number>().DestrMe();
			DestrMe(0f);
		}

		
	}


	void DestrMe(float timer)
	{
		GameObject asd =  Instantiate(postBullet, transform.position, Quaternion.identity);//Quaternion.identity
		Destroy(asd, 2f) ;
		Destroy(gameObject, timer);
	}
}
