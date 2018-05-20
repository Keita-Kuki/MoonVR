using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public UnityEngine.UI.Text timer;
	public GameObject player;
    private float countTime;
	bool isstarted;
	bool isgoaled;
	bool flag;

    // Use this for initialization
    void Start () {
		countTime = 0f;
		timer = GetComponent<UnityEngine.UI.Text>();
		timer.text = "000";
		flag = false;
    }

    // Update is called once per frame
    void Update () {
		isstarted = player.GetComponent<EhanMove>().isstarted;
		isgoaled = player.GetComponent<EhanMove>().isgoaled;
		if(isstarted && !isgoaled){
			countTime += Time.deltaTime; //スタートしてからの秒数を格納
			timer.text = countTime.ToString("F1"); //小数2桁にして表示
		}else if(!isstarted){
			timer.text = "NOT";
		}else if(isgoaled && !flag){
			flag = true;
			timer.text += " <- Nice Fight!!";
			timer.fontSize = 50;
		}
		
    }
}
