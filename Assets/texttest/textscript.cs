using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textscript : MonoBehaviour {
	public string[] text;//テキスト
	public float timer;//一文字表示タイマー
	public Text textbox;//text
	public int textnunber=0;//文字カウント（現在の現在の文字数）
	public int alltextnunber=0;//テキストの配列の番号
	public float speed;//一文字表示の時間
	public bool textcheck;//テキストが表示されてる最中かそうでないか

	void Start () {
		textbox.text = "";//テキスト初期化
		textcheck = true;//テキスト表示開始
	}

	void Update () {

		if (textcheck) {
			//テキスト表示最中にクリックしたとき最後までテキストを表示させる
			if (Input.GetMouseButtonUp (0)) {
				nexttext();
				textcheck = false;//テキスト表示終了
			}

			//現在の文字数が最後まで表示されるまで起動
			if (textnunber < text[alltextnunber].Length) {
				
				timer += Time.deltaTime;//時間カウント

				//表示する文字が半角スペースなら改行
				if (text[alltextnunber] [textnunber] == ' ') {
					timer = 0;//タイマー初期化

						textbox.text += "\n";//改行
						textnunber++;//次の文字へ

				//一定時間になったら次の文字を表示
				} else if (timer > speed) {
					timer = 0;//タイマー初期化
					textbox.text += text [alltextnunber] [textnunber];//一文字追加
					textnunber++;//文字カウントを進める
				}
			}

			//文字をすべて表示されていたら表示を終了
			if (textnunber == text[alltextnunber].Length) {
				textcheck = false;//表示終了
			}

		} else {
			//表示が終了してるときにクリックしたら次のテキストに切り替える
			if (Input.GetMouseButtonUp (0)) {
				textbox.text = "";//テキスト初期化
				if (alltextnunber < text.Length-1) {
					alltextnunber++;//次の配列に
				}
				textnunber = 0;//文字数カウント初期化
				textcheck = true;//表示開始
			}
		}
	}

	//テキストを最後まで表示させる
	void nexttext()
	{
		for (; textnunber< text[alltextnunber].Length; textnunber++) {
			if (text[alltextnunber] [textnunber] == ' ') {
				textbox.text += "\n";//改行
			} else {
				textbox.text += text[alltextnunber] [textnunber];//一文字表示
			}
		}
	}
}
