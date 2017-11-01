using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using live2d;

public class live2dscript : MonoBehaviour {
	public TextAsset moc;
	public Texture2D[] texture;
	private Live2DModelUnity live2Dmodel;

	// Use this for initialization
	void Start () {
		
		//live2d初期化
		Live2D.init ();

		//モデルデータ読み込み？
		live2Dmodel = Live2DModelUnity.loadModel (moc.bytes);

		//テクスチャー読み込み
		live2Dmodel.setTexture (0, texture);

		//モデルの幅を獲得
		float modelwidth = live2Dmodel.getCanvasWidth ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
