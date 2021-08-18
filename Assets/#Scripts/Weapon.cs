using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bullet;
	public float offset;
	public float startShotTime;
	public bool death = false;
	public Transform ff;
	public GameObject LightVector;


	private void Start()
	{
		LightVector.SetActive(false);
		ff = firePoint.GetChild(0);
	}


	void Update()
	{
		if (death) return;
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotateZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        //ff.rotation = Quaternion.Euler(0f, 0f, -(rotateZ + offset)/2);
        ff.rotation = Quaternion.Euler(0f, 0f, 0f);

		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
		if (Input.GetMouseButtonDown(1))
		{
			LightVector.SetActive(true);
		}
		if (Input.GetMouseButtonUp(1))
		{
			LightVector.SetActive(false);
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
