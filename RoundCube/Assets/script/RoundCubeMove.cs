using UnityEngine;
using System.Collections;


public class RoundCubeMove : MonoBehaviour {

	Transform target;
	public Hashtable tableY = new Hashtable();
	public Hashtable tableX = new Hashtable();
	public Hashtable table_lt = new Hashtable();	


	void Start()
	{
		target = GameObject.Find("Cylinder_lt").transform;





		//平面移動のテーブル設定
		tableY.Add("y", 0.5f);
		tableY.Add("oncomplete", "Curve");	// トゥイーン終了時にCurve()を呼ぶ
		tableY.Add("oncompleteparams", "lt");	// Curve()の引数に渡す値
		tableY.Add("time",1f);
		
		
		tableX.Add("x", 0);
		tableX.Add("time",1f);	

		//tableY.Add("oncomplete", "Curve");	// トゥイーン終了時にCurve()を呼ぶ
		//tableY.Add("oncompleteparams", "lt");	// Curve()の引数に渡す値

		
		
		var pos_lt = new Vector3[4];
		pos_lt[0] = new Vector3(0.6376f, 0.5587f, 0);
		pos_lt[1] = new Vector3(0.606f, 0.606f, 0);
		pos_lt[2] = new Vector3(0.5597f, 0.6384f, 0);
		pos_lt[3] = new Vector3(0.5f, 0.65f, 0);
		//pos_lt[4] = new Vector3(0.5f, 0.65f, 0);
		
		table_lt.Add("path",pos_lt);
		table_lt.Add("onupdate", "Lookcore");		// トゥイーンを開始してから毎フレームUpdateHandler()を呼ぶ
		table_lt.Add("oncomplete", "MoveXminus");	// トゥイーン終了時にCompleteHandler()を呼ぶ
		table_lt.Add("time",1f);	
		iTween.MoveTo(gameObject, tableY);
	}
	

		
		//iTween.MoveTo(gameObject,iTween.Hash("path",pos,
		 //                                    "time",5f,
		 //                                    "easeType","linear",
		 //   									"loopType","none"));
	void MoveXminus ()
	{
		iTween.MoveTo(gameObject, tableX);
	}

	void Lookcore ()
	{
		transform.LookAt (target);
	}
	
	void Curve(string type)
	{
		switch (type) {
		case "lt":
				iTween.MoveTo(gameObject,table_lt);
			break;
		
		}
	}
	void Awake () {
		// charm of iTween
		iTween.Init(this.gameObject);
	}
}