using UnityEngine;
using System.Collections;

public class myTarget : MonoBehaviour {
	//定数
	private const string TARGETTAG = "Shell";	//対象となるオブジェクトのタグ

	//変数
	[SerializeField]	//効果音(発射音)
	private AudioClip SEclip = null;
	private AudioSource SE;
	
	void Start () {
		// 効果音の再生準備
		SE = gameObject.AddComponent<AudioSource> ();
		SE.clip = SEclip;
	}

	void Update () {

	}

	void OnTriggerEnter(Collider collider) {	//衝突したときに実行（コライダコンポーネント）
		if(collider.gameObject.CompareTag(TARGETTAG)) {	//"Enemy"タグのオブジェクトが衝突したとき

			//演出
			//効果音再生
			SE.Play ();
			//破片を飛ばす
			gameObject.AddComponent (typeof(myExplosion));

			//colliderの操作
			//衝突した砲弾を削除
			Destroy(collider.gameObject);

			//gameObjectの操作
			//メッシュを削除（透明化）
			gameObject.GetComponent<MeshFilter>().mesh.Clear();
			//コライダを削除（重複判定しないように）
			Destroy(gameObject.GetComponent<CapsuleCollider>());
			//削除予約
			Object.Destroy(gameObject, 2F);
		}
	}
}
