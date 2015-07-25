using UnityEngine;
using System.Collections;
public class Lookat : MonoBehaviour
{
	Transform target;
	void Start ()
	{
		target = GameObject.Find("RoundCube").transform;
	}
	void Update ()
	{
	transform.LookAt (target);
	}
}
