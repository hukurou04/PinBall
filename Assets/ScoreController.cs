using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	//合計
	private int score = 0;

	//Scoreを表示する
	private GameObject scoreText;



	// Use this for initialization
	void Start () {
		//scoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");


		//タグによってスコアの得点をつける
		/*if (tag == "SmallStarTag") {
			this.score += 10;
		} else if (tag == "LargeStarTag") {
			this.score += 20;
		} else if (tag == "SmallCloudTag") {
			this.score += 30;
		} else if (tag == "LargeCloudTag") {
			this.score += 50;
		}*/

	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.GetComponent<Text> ().text = score.ToString();
	}

	void OnCollisionEnter(Collision other){
		if ( other.gameObject.tag == "SmallStarTag") {
			this.score += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			this.score += 20;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			this.score += 30;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			this.score += 50;
		}
	}
}
