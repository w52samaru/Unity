using UnityEngine;
using System.Collections;

public class myTriger : MonoBehaviour {
	public static bool flag = false;	//呼び出し中か否か
	public enum rotDir {	//回転方向列挙
		none, right, left, up, down, rollR, rollL
	}
	public static rotDir dir;	//回転方向
	
	[SerializeField]	//効果音
	private AudioClip SErotateClip = null;
	public static AudioSource SErotate;

	void Start () {
		// 効果音の再生準備
		var emptyObject = new GameObject ("AudioSErotate");
		SErotate = emptyObject.AddComponent<AudioSource> ();
		SErotate.clip = SErotateClip;
	}
	void Update () {
		if (flag == false) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				flag = true;
				dir = rotDir.right;
				gameObject.AddComponent (typeof(myRotate));
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				flag = true;
				dir = rotDir.left;
				gameObject.AddComponent (typeof(myRotate));
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				flag = true;
				dir = rotDir.up;
				gameObject.AddComponent (typeof(myRotate));
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				flag = true;
				dir = rotDir.down;
				gameObject.AddComponent (typeof(myRotate));
			}
			if (Input.GetKeyDown (KeyCode.P)) {
				flag = true;
				dir = rotDir.rollR;
				gameObject.AddComponent (typeof(myRotate));
			}
			if (Input.GetKeyDown (KeyCode.O)) {
				flag = true;
				dir = rotDir.rollL;
				gameObject.AddComponent (typeof(myRotate));
			}
		}
	}
}
