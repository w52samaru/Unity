using UnityEngine;
using System.Collections;

public class myRocketLauncher : MonoBehaviour {
	
	[SerializeField]	//効果音(発射音)
	private AudioClip SEclip = null;
	private AudioSource SE;

	private float speed = 10f;

	// Use this for initialization
	void Start () {
		// 効果音の再生準備
		SE = gameObject.AddComponent<AudioSource> ();
		SE.clip = SEclip;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)) {
			FireRocket();	//砲弾発射
		}
		if (Input.GetKey (KeyCode.V)) {
			FireBeam();
		}
	}

	void FireRocket () {
		//砲弾生成
		GameObject shell = (GameObject)Resources.Load ("Prefabs/Shells/CubeShell");
		var shellObject = (GameObject) Instantiate (shell, gameObject.transform.position, gameObject.transform.rotation);
		
		//砲弾発射
		shellObject.GetComponent<Rigidbody> ().velocity = shellObject.transform.right * speed;

		//削除予約
		Object.Destroy ( shellObject, 2F);

		//効果音再生
		SE.Play ();
	}
	void FireBeam() {
		//砲弾生成
		GameObject shell = (GameObject)Resources.Load ("Prefabs/Shells/CylinderShell");
		var shellObject = (GameObject) Instantiate (shell, gameObject.transform.position, gameObject.transform.rotation);
		
		//砲弾発射
		shellObject.GetComponent<Rigidbody> ().velocity = shellObject.transform.right * speed;
		
		//削除予約
		Object.Destroy ( shellObject, 2F);
	}
}
