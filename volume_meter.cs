using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume_meter : MonoBehaviour
{
    //取得したい、設定したいオブジェクトの宣言
    public GameObject MorphTarget;　//オブジェクトの選択用の箱
    GameObject Text;
    SkinnedMeshRenderer renderer;　//取得したいモーフの値の宣言
    //パラメーターのオブジェクト(Bar_a,i,u,e,o)をListに代入
    public List<GameObject> Bars = new List<GameObject>();
    List<float> volumeText;
    int count;　//テキスト更新用のカウンタ

    void Start()
    {
        count = 0;

        renderer = MorphTarget.GetComponent<SkinnedMeshRenderer>();　//モーフの値
        Text = GameObject.Find("Text"); //テキスト取得

        Text.GetComponent<Text>().text = "";


    }

 
    void Update()
    {
        /*
        テキストにリストの情報を代入、代入した後、
        テキストを空にしないと文字が増え続ける為、
        空の文字を代入
        */
        if (count <= Bars.Count)
        {
            Text.GetComponent<Text>().text = "";
            count = 0;
        }

        for (int i = 0; i < Bars.Count; i++)
        {
            //Debug.Log(Bars[i].name);
            float volume = renderer.GetBlendShapeWeight(i); //テキスト変数に代入
            Text.GetComponent<Text>().text += Bars[i].name + " : " + volume.ToString("F0") + "\n";
            Bars[i].GetComponent<RectTransform>().sizeDelta = new Vector2( 400 * (volume / 100), 6); //棒に反映

        }

        count++;

    }
}
