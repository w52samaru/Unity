using UnityEngine;

public class my02CreateObjects : MonoBehaviour {

	// UnityEngine.GameObject
	// public class sealed GameObject : Object
	void start() {//オブジェクト生成
		//引数なし
		var obj1 = new GameObject();
		//名前のみ指定
		var obj2 = new GameObject("ObjectName");
		//名前とコンポーネントを指定
		var obj3 = new GameObject("ObjectName"/*, component,,,*/);
	}

}
