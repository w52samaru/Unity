using UnityEngine;
using System.Collections;

public class SomeButtonBehaviour : MonoBehaviour, ButtonBehaviour {

	public void TouchDown(){
		Debug.Log("Tap");
		//選択画面を出す(canvas2を使用)
		GameObject prefab = (GameObject)Resources.Load ("Prefab/Canvas2");
		Instantiate (prefab, transform.position, Quaternion.identity);
	

		if (this.gameObject.tag == "okeru") {
			GameObject prefab2 = (GameObject)Resources.Load ("Prefab/build");
			// プレハブからインスタンスを生成
			Instantiate (prefab2, this.transform.position, Quaternion.identity);

		} else if (this.gameObject.tag == "build") {
			Destroy (gameObject);
		}

	}
	
	public void TouchUp(){
		// ここにボタンが離されたときの処理を書く。

	}
}