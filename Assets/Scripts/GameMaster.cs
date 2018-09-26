using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;
	public static bool dead;
	public static int score;
	public static  int wave;
    public static int killCounter = 0;
    public static bool tantrum_ready = false;
  public Transform playerPrefab;

	void Awake () {
				if (gm == null) {
					gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
				}
				dead = false;
				score = 1000;
				wave = 1;
	}
  /*
	public IEnumerator RespawnPlayer () {
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		GameObject clone = Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
		Destroy (clone, 3f);
	}
    */


	public static void KillPlayer (Player_Health player) {
		//Destroy(player child arm )
		dead = true;
		//Destroy (player.transform.GetChild(1).gameObject);
		player.transform.GetChild(0).gameObject.SetActive(false);
		//gm.StartCoroutine (gm.RespawnPlayer());
	}
	public static bool isdead(){
		return dead;
	}

	public static void KillEnemy (Enemy enemy) {
        Debug.Log("killed");
        AudioManager.PlaySound("zombie_dead");
		score += 10;
	    GameObject.Find("zombieSpawn").GetComponent<spawnScript>().killed++;
		GameObject.Find("zombieSpawn").GetComponent<spawnScript>().zombiesonmap--;
		Destroy (enemy.gameObject);

        killCounter++;
        if(killCounter == 5)
        {
            Debug.Log("killed 5");
            tantrum_ready = true;
        }
	}

    public static bool canTantrum()
    {
        Debug.Log("can tantrum");
        return tantrum_ready;
    }

    public static void setTantrum(bool x)
    {
        tantrum_ready = x;
        killCounter = 0;
    }

	//Hud elements
	public static int getscore(){
		return score;
	}
	public static void changescore( int change){
			score -= change;
	}
	public static int getwave(){
			return wave;
	}
	public static void nextwave(){
		  AudioManager.PlaySound("wave");
			wave += 1;
	}
}
