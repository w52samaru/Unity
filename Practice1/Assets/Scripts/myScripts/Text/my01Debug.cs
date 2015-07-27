using UnityEngine;

// スクリプトクラスに必要なスーパークラス
//Start()やUpdate()などがある
//public class Monobehaviour : Behaviour

	/*	System.Object
	 *		UnityEngine.Object
	 *			UnityEngine.Component
	 *				UnityEngine.Behaviour
	 *					UnityEngine.MonoBehaviour
	 */
public class my01Debug : MonoBehaviour {
	
	// UnityEngine.MonoBehaviour
	// public class MonoBehaviour : Behaviour
	void Awake(){

		//Start()よりも先に呼び出される
		//スクリプト自身の初期化用メソッド
		//つまりコンストラクタのようなもの
	}
	void Start(){

		//全てのオブジェクトのAwake()の後に呼び出されるメソッド
		//ゲームオブジェクトの初期化用メソッド
	}
	
	// Unity.Engine.Debug
	// public sealed class Debug
	void myDebug(){//デバック関連
		
		//ログ表示
		//rメッセージ		関連オブジェクトなし
		Debug.Log ("Stand by Ready!");
		//							アタッチしたオブジェクトに関連
		Debug.Log ("Stand by Ready!", gameObject);
		//							スクリプト自身に関連
		Debug.Log ("Stand by Ready!", this);
		
		//警告
		Debug.LogWarning ("Warning message", gameObject);
		//エラー
		Debug.LogError ("Error message", gameObject);
		
		//一時停止	※次フレーム更新時に停止・厳密な停止には設定が必要(P25-27)
		Debug.Break ();
	}
}
