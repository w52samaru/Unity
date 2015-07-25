using UnityEngine;
using System.Collections;

public class MoveSample1 : MonoBehaviour {



	void Start () {
		//vecter3は三次元の座標が入る変数 Vecter3 test = (2, 3, 0);
		var pos = new Vector3[5];
		pos[0] = new Vector3(2f, 3f, 0f);
		pos[1] = new Vector3(2f, 5f, 0f);
		pos[2] = new Vector3(-2f, 5f, 0f);
		pos[3] = new Vector3(-2f, 3f, 0f);
		pos[4] = new Vector3(0f, 3f, 0f);

		/*iTween.MoveTo(動かしたいオブジェクト名 , 座標など);

		iTween.Hash("path",pos,
					"time",何秒かけて動くか,
					"easeType","動きの種類",
					"loopType","[none,loop,pingPong]");
		*/

		iTween.MoveTo(gameObject,iTween.Hash("path",pos,
		                                     "time",2f,
		                                     "easeType","easeOutBounce",
		                                     "loopType","loop"));
	}
}