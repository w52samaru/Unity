using UnityEngine;
using System.Collections;

public class mySE : MonoBehaviour {
	
	[SerializeField]	//効果音
	private AudioClip SEclip = null;
	private AudioSource SE;
	// Use this for initialization
	void Start () {
		// 効果音の再生準備
		SE = gameObject.AddComponent<AudioSource> ();
		SE.clip = SEclip;
		SE.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
