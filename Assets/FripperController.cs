using System.Collections;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;


	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {

		/*int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != touchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}*/



		for (int i = 0; i < Input.touchCount; i++) {

			Touch touch = Input.GetTouch (i);
			
			//左画面タッチの時左フリッパーを動かす
			if (touch.phase == TouchPhase.Began) {
				if (tag == "LeftFripperTag") {
					if (Input.touches [i].position.x <= Screen.width / 2) {
						SetAngle (this.flickAngle);
				
					}
				}
			
				//右画面タッチの時右フリッパーを動かす
				if (tag == "RightFripperTag") {
					if (Input.touches [i].position.x >= Screen.width / 2) {
						SetAngle (this.flickAngle);
					} 
				}
			} else if (touch.phase == TouchPhase.Ended) {
				SetAngle (this.defaultAngle);
			}
		}
			

			//左画面タッチを離した時左フリッパーを元に戻す
		
				/*if (Input.touches [i].position.x <= Screen.width / 2 && tag == "LeftFripperTag" ) {
					SetAngle (this.defaultAngle);
				}*/
			

			//右画面タッチを離した時右フリッパーを元に戻す

				/*if (Input.touches [i].position.x >= Screen.width / 2 && tag == "RightFripperTag" ) {
					SetAngle (this.defaultAngle);
				}*/
			
		

		//左矢印キーを押した時左フリッパーを動かす
		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle(this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.defaultAngle);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle(this.defaultAngle);
		}

	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}

}
