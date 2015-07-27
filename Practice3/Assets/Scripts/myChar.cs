using UnityEngine;
using System.Collections;
/*
 * Tag "Enemy"の付く敵オブジェクトの移動に関するクラス
 * イベントのたびに敵オブジェクトの座標を'0.1'刻みで四捨五入調整する
 * 敵の幅は50pxとする
 */
public class myChar : MonoBehaviour {

	//---定数---------------------------------------------------------------------------------------------
	//初期数値
	private const float GOS = 0.48F;	//オブジェクトの幅	※画像は50px正方形と仮定
	//GOS = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;	//0.1単位
	private const float BGS = 5.0F;	//立方体の幅	※背景画像は500px正方形と仮定

	private const float MOVESPEED = 0.02F;
	//-----------------------------------------------------------------------------------------------------

	
	//移動範囲
	private	float max;	//境界位置（正）
	private float min;	//境界位置-（負）
	//
	
	//移動初期値
	private float dx;	//移動量
	private Vector3 dir;	//移動方向
	
	//面位置情報	surface
	private enum sur {
		none, front, right, left, top, bottom, back
	}
	[SerializeField]
	private string serSur = null;	//コンポーネントで指定
	private sur thissur = sur.none;	//Awake()で設定

	private GameObject[] block;	//衝突判定用

	//外部から回転をするときに使用
	//public float deg;	//回転角度
	
	void Awake() {
		//コンポーネント引数から初期面位置指定処理
		if (serSur == "front")
			thissur = sur.front;
		else if (serSur == "right")
			thissur = sur.right;
		else if (serSur == "left")
			thissur = sur.left;
		else if (serSur == "top")
			thissur = sur.top;
		else if (serSur == "bottom")
			thissur = sur.bottom;
		else if (serSur == "back")
			thissur = sur.back;
		else {//ありえないはず
			thissur = sur.none;
			Debug.LogError ("Error");
		}
	}
	
	void Start () {
		Debug.Log (gameObject.GetComponent<SpriteRenderer> ().bounds.size.x);
		//移動範囲設定
		//GOS = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;	//0.1単位
		//BGS = 5.0F;	//0.1単位
		//面切り替え境界位置
		max = + (BGS / 2) - (GOS / 2);	//0.1単位
		min = - (BGS / 2) + (GOS / 2);	//0.1単位
		
		//移動初期値設定
		dx = MOVESPEED;	//移動量
		dir = Vector3.down;	//移動方向

		//衝突判定用
		block = GameObject.FindGameObjectsWithTag ("Block");	//Blockタグのオブジェクトを取得

	}
	
	void Update () {
		//範囲外なら面移動
		bool flag = false;	//分岐のため
		if (thissur != sur.front && thissur != sur.back && flag != true) {	//前面・背面でない
			if (gameObject.transform.position.z > max) {
				Debug.Log (thissur.ToString (), gameObject);
				changesur (sur.back);
				flag = true;
			} else if (gameObject.transform.position.z < min) {
				Debug.Log (thissur.ToString (), gameObject);
				changesur (sur.front);
				flag = true;
			}
		}
		if (thissur != sur.left && thissur != sur.right && flag != true) {	//左面・右面でない
			if (gameObject.transform.position.x > max) {	//x座標が境界外
				Debug.Log (thissur.ToString (), gameObject);
				changesur (sur.left);
				flag = true;
			} else if (gameObject.transform.position.x < min) {
				Debug.Log (thissur.ToString (), gameObject);
				changesur (sur.right);
				flag = true;
			}
		}
		if (thissur != sur.top && thissur != sur.bottom && flag != true) {	//上面・底面でない
			if (gameObject.transform.position.y > max) {
				Debug.Log (thissur.ToString (), gameObject);
				changesur (sur.top);
				flag = true;
			} else if (gameObject.transform.position.y < min) {
				Debug.Log (thissur.ToString (), gameObject);
				changesur (sur.bottom);
				flag = true;
			}
		}
		//テスト用
		//walkWay ();
		//changeDir ();	//オブジェクトの操作
		//----------
		//移動
		gameObject.transform.Translate (dir * dx, Space.Self);	//自身の向きを基準に移動
	}

	private void changesur(sur nextsur) {
		//算出する必要のある数値
		Vector3 axis = Vector3.zero;	//回転軸
		float x = 0;	//座標
		float y = 0;
		float z = 0;

		//前処理
		if (thissur == sur.front)
			z = min;
		else if (thissur == sur.back)
			z = max;
		else if (thissur == sur.right)
			x = min;
		else if (thissur == sur.left)
			x = max;
		else if (thissur == sur.top)
			y = max;
		else if (thissur == sur.bottom)
			y = min;
		else
			Debug.LogError ("Error");

		if (nextsur == sur.front)
			z = -BGS / 2;
		else if (nextsur == sur.back)
			z = BGS / 2;
		else if (nextsur == sur.right)
			x = -BGS / 2;
		else if (nextsur == sur.left)
			x = BGS / 2;
		else if (nextsur == sur.top)
			y = BGS / 2;
		else if (nextsur == sur.bottom)
			y = -BGS / 2;
		else
			Debug.LogError ("Error");

		if (thissur == sur.front) {
			if (nextsur == sur.right) {
				axis = Vector3.up;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.left) {
				axis = Vector3.down;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.top) {
				axis = Vector3.right;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else if (nextsur == sur.bottom) {
				axis = Vector3.left;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else {
				Debug.LogError ("Error");
			}
		} else if (thissur == sur.back) {
			if (nextsur == sur.right) {
				axis = Vector3.down;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.left) {
				axis = Vector3.up;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.top) {
				axis = Vector3.left;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else if (nextsur == sur.bottom) {
				axis = Vector3.right;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else {
				Debug.LogError ("Error");
			}
		} else if (thissur == sur.right) {
			if (nextsur == sur.front) {
				axis = Vector3.down;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.back) {
				axis = Vector3.up;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.top) {
				axis = Vector3.back;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else if (nextsur == sur.bottom) {
				axis = Vector3.forward;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else {
				Debug.LogError ("Error");
			}
		} else if (thissur == sur.left) {
			if (nextsur == sur.front) {
				axis = Vector3.up;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.back) {
				axis = Vector3.down;
				y = Mathf.Round(gameObject.transform.position.y*10.0F)/10.0F;
			} else if (nextsur == sur.top) {
				axis = Vector3.forward;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else if (nextsur == sur.bottom) {
				axis = Vector3.back;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else {
				Debug.LogError ("Error");
			}
		} else if (thissur == sur.top) {
			if (nextsur == sur.front) {
				axis = Vector3.left;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else if (nextsur == sur.back) {
				axis = Vector3.right;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else if (nextsur == sur.right) {
				axis = Vector3.forward;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else if (nextsur == sur.left) {
				axis = Vector3.back;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else {
				Debug.LogError ("Error");
			}
		} else if (thissur == sur.bottom) {
			if (nextsur == sur.front) {
				axis = Vector3.right;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else if (nextsur == sur.back) {
				axis = Vector3.left;
				x = Mathf.Round(gameObject.transform.position.x*10.0F)/10.0F;
			} else if (nextsur == sur.right) {
				axis = Vector3.back;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else if (nextsur == sur.left) {
				axis = Vector3.forward;
				z = Mathf.Round(gameObject.transform.position.z*10.0F)/10.0F;
			} else {
				Debug.LogError ("Error");
			}
		}
		//移動
		thissur = nextsur;	//現在面を更新
		gameObject.transform.Rotate (axis, 90, Space.World);	//90度回転
		gameObject.transform.position = new Vector3 (x, y, z);//面移動後初期位置

		//微調整	処理に負荷となる場合には削除してもかまわない-------------------------------------------------------
		ajustRotation ();
		//------------------------------------------------------------------------------------------------------------------------
	}

	private void changeDir(){	//オブジェクトの操作（テスト用）
		if (Input.GetKeyDown (KeyCode.D))	dir = Vector3.right;	//右方向へ
		else if (Input.GetKeyDown (KeyCode.A))	dir = Vector3.left;	//左方向へ
		else if (Input.GetKeyDown (KeyCode.W))	dir = Vector3.up;	//上方向へ
		else if (Input.GetKeyDown (KeyCode.S))	dir = Vector3.down;	//下方向へ
		else if(Input.GetKeyDown (KeyCode.Q))	gameObject.transform.Rotate (Vector3.forward, 90, Space.Self);	//45度左回転
		else if(Input.GetKeyDown (KeyCode.E))	gameObject.transform.Rotate (Vector3.back, 90, Space.Self);	//45度右回転
	}
	
	private struct trap {	//方向転換情報構造体
		public Vector3 pos;
		public Vector3 dir;
		public trap (Vector3 apos, Vector3 adir) {
			pos = apos;
			dir = adir;
		}
	}

	private trap[] mytrap = {	//方向転換情報登録
		new trap (new Vector3 (2.0f, 0.0F, -2.5F), Vector3.up),
		new trap (new Vector3 (2.0f, 2.0F, -2.5F), Vector3.left),
		new trap (new Vector3 (-2.0f, 2.0F, -2.5F), Vector3.down),
		new trap (new Vector3 (-2.0f, -2.0F, -2.5F), Vector3.right),
		new trap (new Vector3 (2.0f, -2.0F, -2.5F), Vector3.up),
	};

	private void walkWay() {	//経路情報を事前に登録しておく場合の処理
		for(int i=0; i<mytrap.Length; i++) {
			if(gameObject.transform.position== mytrap[i].pos)	//方向転換場所
				dir = mytrap[i].dir;
			/*
			 * 進行方向角度を調整するのではなく、回転させて位置調整した方がいいかもしれない
			 */
		}
	}

	//一度に複数回実行されることを防止
	private const int denyCount = 22;		//実行されてから受け付けないフレーム数
	public int former = 0;	//前回実行されたフレーム数
	
	public void forceTurn(float deg, int count) {	//連続判定防止
		if ( count - former > denyCount) {	//一定時間以上経過しているなら
			gameObject.transform.Rotate (Vector3.forward, deg, Space.Self);	//回転
			ajustPosition ();	//座標の調整
			ajustRotation ();	//回転角の調整
			former = count;	//同時複数回実行防止のためのカウント
		}
	}
	public void forceTurn(float deg) {	//カウンタによる処理が必要ない場合
		gameObject.transform.Rotate (Vector3.forward, deg, Space.Self);	//回転
		ajustPosition ();	//座標の調整
		ajustRotation ();	//回転角の調整
	}

	//衝突すると左右に方向転換する
	/*
	private void avoidColide() {
		foreach (GameObject b in block) {
			if (gameObject.GetComponent<CircleCollider2D> ().IsTouching(b.GetComponent<BoxCollider> ())) {	//対象と接触
				float deg = (Random.value > 0.5) ? 90 : -90;
				forceTurn (deg);
			}
		}
	}
	*/

	private void ajustPosition() {	//座標の微調整
		gameObject.transform.position = new Vector3(	//0.5単位で調整
		                                            Mathf.Round(gameObject.transform.position.x*2.0F)/2.0F	,
		                                            Mathf.Round(gameObject.transform.position.y*2.0F)/2.0F	,
		                                            Mathf.Round(gameObject.transform.position.z*2.0F)/2.0F	);
	}

	private void ajustRotation() {	//回転角度の微調整
		gameObject.transform.rotation = new Quaternion(	//四元数0.1単位で調整
		                                               Mathf.Round(gameObject.transform.rotation.x*10.0F)/10.0F	,
		                                               Mathf.Round(gameObject.transform.rotation.y*10.0F)/10.0F	,
		                                               Mathf.Round(gameObject.transform.rotation.z*10.0F)/10.0F	,
		                                               Mathf.Round(gameObject.transform.rotation.w*10.0F)/10.0F	);
	}

}