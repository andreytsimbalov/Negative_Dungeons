using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bullet;
	public float offset;
	public float startShotTime;

	private void Start()
	{

	}


	void Update()
	{

		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotateZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		StartCoroutine(ShootCor());
	}
	IEnumerator ShootCor()
	{

		yield return new WaitForSeconds(0.01f);
		Instantiate(bullet, firePoint.position, firePoint.rotation);

		//yield return null;
	}
}
