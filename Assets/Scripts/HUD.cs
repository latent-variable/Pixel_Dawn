using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Sprite[] HeartSprites;
	public Image HearthUI;
	private Player_Health player;
	private int index = 0;
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
		if(player == null){
			Debug.LogError("In HUD, no player health object found in player");
		}
	}
	void Update(){
			if(player.stats.curHealth/20 <= 0){
				index = 0;
			}else{
				index = player.stats.curHealth/20;
			}
			HearthUI.sprite = HeartSprites[index];

	}
}
