using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterWait : MonoBehaviour
{
	public float lifeTime ;
	private void Start()
	{
		StartCoroutine(StartDelay());
	}
	private IEnumerator StartDelay()
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
	}
}
