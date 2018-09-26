using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {

	public Transform[] spawnLocation;
	public float spawnTime = 3.0f;
	public GameObject[] enemy;
	public int killed;
	UnityEngine.Camera cam;
	public Transform obj;
	public int wave;
	private int maxzombiesinwave;
	private int maxzombieinmap;
	public int zombies;
	public int zombiesonmap;

	// Use this for initialization
	void Start () {
		zombiesonmap = 0;
		killed = 0;
		wave = 1;
		maxzombieinmap = 25;
		maxzombiesinwave = 25;
		zombies = 0;
		cam = UnityEngine.Camera.main;
		//obj = enemy.GetComponent<Transform>();
		InvokeRepeating("zombieSpawn", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Update () {
		if(killed == maxzombiesinwave){
			StartCoroutine(nextWave());
		}
		else if(zombiesonmap == maxzombieinmap){
			CancelInvoke();
		}
		else if(zombies == maxzombiesinwave){
			CancelInvoke();
		}
		else{
			if(!IsInvoking("zombieSpawn")){
				InvokeRepeating("zombieSpawn",spawnTime,spawnTime);
			}
		}
	}

	IEnumerator nextWave(){
		GameMaster.nextwave();
		wave++;
		killed = 0;
		maxzombiesinwave += 5;
		zombies = 0;
		yield return new WaitForSeconds(5);
	}

	void zombieSpawn(){
		int spawnIndex = Random.Range(0, spawnLocation.Length);
		int enemyIndex = Random.Range(0, enemy.Length);
		obj = spawnLocation[spawnIndex];
		Vector3 pos = cam.WorldToViewportPoint(obj.position);
		if(pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1){
			Debug.Log("IM ON CAMERA");
		}
		else{
			//totalzombiesspawnedinwave++;
			zombies++;
			zombiesonmap++;
			Instantiate(enemy[enemyIndex], spawnLocation[spawnIndex].position, spawnLocation[spawnIndex].rotation);
		}
	}
}
