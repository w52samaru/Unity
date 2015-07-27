using System.Linq;
using UnityEngine;

public class my05FindObjects : MonoBehaviour {
	
	private GameObject findedObj;	// Find()

	private const int LawOfCycles = 8;

	// Use this for initialization
	void Start () {
		
		//おまけ	処理が重いのでUpdate()等では使うべきではない
		// [Wrapperlesslcall]
		// public static GameObjec5t Find(string name);
		findedObj = GameObject.Find ("Quad");

		// GameObject	tagプロパティ
		// public string tag { get; set; }	タグを設定する
		findedObj.tag = "Player";

		// public static GameObject FindWithTag(string tag);	FindGameObjectWithTagの省略形
		// public static GameObject FindGameObjectWithTag(string tag);		タグに合致する1つを返す
		// public static GameObject[] FindGameObjectsWithTag(string tag);	複数のオブジェクトを返す
		// ※Objectが複数形か否かに違いあり
		var tag = "Player";
		foreach (var obj in GameObject.FindGameObjectsWithTag (tag))
			Debug.Log (obj.name, obj);

		// GameObject	layerプロパティ
		// public int layer { get; set; }
		var tempobj = GameObject.FindGameObjectsWithTag (tag).
			FirstOrDefault (x => x.layer == LawOfCycles);

		if(tempobj == null) return;
		Debug.Log (tempobj.name + " is gone. Guided away by the Law of Cycles.");
		Object.Destroy (tempobj);
	}
	
	// Update is called once per frame
	void Update () {
		findedObj.transform.Rotate (0, 1, 0);	//回転
	}
}
