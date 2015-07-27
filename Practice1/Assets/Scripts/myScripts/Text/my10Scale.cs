using UnityEngine;
using System.Collections;

public class my10Scale : MonoBehaviour {
	
	private GameObject pcube;
	private GameObject ccube;

	void Start () {
		// Transformクラス	localScaleプロパティ
		// public Vector3 localScale { get; set; }
		pcube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		ccube = GameObject.CreatePrimitive (PrimitiveType.Cube);

		ccube.transform.parent = pcube.transform;
		ccube.transform.localPosition = new Vector3 (0, -3, 0);

		pcube.transform.localScale = new Vector3 (5, 1, 5);
		ccube.transform.localScale = new Vector3 (0.5F, 3, 0.5F);
		
		Debug.Log ("localScale: " + ccube.transform.localScale);
		Debug.Log ("lossyScale: " + ccube.transform.lossyScale);
	}
	
	// Update is called once per frame
	void Update () {
		ccube.transform.localScale = new Vector3 (ccube.transform.localScale.x * 1.01F,
			    	    	    	    	    	    	                 ccube.transform.localScale.y * 1.01F,
		    	    	    	    	    	    	    	             ccube.transform.localScale.z * 1.01F);

	}
}
