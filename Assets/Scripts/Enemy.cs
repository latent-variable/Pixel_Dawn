using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float sound_time = 0.1f;
	private float hit_sound =0.0f;
	[System.Serializable]
	public class EnemyStats {
		public int Health = 100;
	}

	public EnemyStats stats = new EnemyStats();

	public void DamageEnemy (int damage) {

		if(hit_sound < Time.time){
				AudioManager.PlaySound("zombie_hit");
				hit_sound = Time.time + sound_time;
		}

		stats.Health -= damage;
		if (stats.Health <= 0)
		{
			GameMaster.KillEnemy (this);
		}
	}
}
