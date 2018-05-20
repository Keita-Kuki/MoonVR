using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

	public UnityEngine.UI.Text timer;
	public GameObject player;
    private float countTime;
	bool isstarted;
	bool isgoaled;
	bool flag;
	bool minus10s;

    // Use this for initialization
    void Start () {
		countTime = 0f;
		timer = GetComponent<UnityEngine.UI.Text>();
		timer.text = "000";
		flag = false;
		minus10s = false;
    }

    // Update is called once per frame
    void Update () {
			isstarted = player.GetComponent<EhanMove>().isstarted;
			isgoaled = player.GetComponent<EhanMove>().isgoaled;
			minus10s = player.GetComponent<EhanMove>().minus10s;

			if(minus10s){
				minus10s = false;
				countTime -= 10;
				player.GetComponent<EhanMove>().Afterminus10s();
			}
		
			if(isstarted && !isgoaled){
				countTime += Time.deltaTime; //スタートしてからの秒数を格納
				timer.text = countTime.ToString("F1"); //小数2桁にして表示
			}else if(!isstarted){
				timer.text = "READY...";
			}else if(isgoaled && !flag){
				flag = true;
				timer.text += " <- Nice Fight!!";
				timer.fontSize = 50;
				Invoke("BacktoTitle", 2f);
			}
		
    }

		void BacktoTitle(){
			SceneManager.LoadScene("Title");
		}


}
