using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        public int curHealth;
        // public int curHealth
        // {
        //     get { return _curHealth; }
        //     set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        // }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }
    public PlayerStats stats = new PlayerStats();

    [SerializeField]
    //private StatusIndicator statusIndicator;

    // Use this for initialization
    void Start () {
        stats.Init();
        /*
        if (statusIndicator == null)
        {
            Debug.LogError("No status indicator referenced on Player");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }*/
    }

	// Update is called once per frame
	void Update () {
		if(transform.position.y <= -10)
        {
            DamagePlayer(500);
        }
	 }
  public void DamagePlayer(int damage)
    {
        AudioManager.PlaySound("character_damage");
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            AudioManager.PlaySound("dead");
            GameMaster.KillPlayer(this);
        }

       // statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }
}
