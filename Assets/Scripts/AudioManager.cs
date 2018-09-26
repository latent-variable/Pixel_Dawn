using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {



    public static AudioClip assault_rifle_S, shotGun_S, pistol_S,
    jump_S, death_S,hover_S, zombie_A_S, zombie_G_S, zombie_D_S,
    character_damage_S, wave_S, grenade_S,cannon_S,sword_S,
    zombie_female_A_S, wolf_A_S, Tantrum_S, zombie_damage_S;

    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        assault_rifle_S = Resources.Load<AudioClip>("sfx_wpn_machinegun_loop10");
        shotGun_S = Resources.Load<AudioClip>("sfx_weapon_shotgun4");
        pistol_S = Resources.Load<AudioClip>("sfx_weapon_singleshot23");
        jump_S = Resources.Load<AudioClip>("sfx_movement_jump21");
        hover_S = Resources.Load<AudioClip>("sfx_movement_jump19_landing");
        death_S = Resources.Load<AudioClip>("bad_event");
        zombie_A_S = Resources.Load<AudioClip>("sfx_deathscream_human12");
        zombie_G_S = Resources.Load<AudioClip>("sfx_deathscream_alien1");
        zombie_D_S = Resources.Load<AudioClip>("sfx_coin_double3");
        character_damage_S = Resources.Load<AudioClip>("sfx_sounds_damage1");
        wave_S = Resources.Load<AudioClip>("sfx_sounds_powerup7");
        grenade_S = Resources.Load<AudioClip>("sfx_exp_short_hard2");
        cannon_S = Resources.Load<AudioClip>("sfx_exp_long5");
        sword_S = Resources.Load<AudioClip>("sfx_wpn_sword1");
        zombie_female_A_S = Resources.Load<AudioClip>( "sfx_deathscream_alien4");
        wolf_A_S = Resources.Load<AudioClip>("sfx_deathscream_human5");
        Tantrum_S = Resources.Load<AudioClip>("sfx_deathscream_human1");
        zombie_damage_S = Resources.Load<AudioClip>("sfx_movement_footsteps1b");

        audioSrc = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "assault_rifle":
                audioSrc.PlayOneShot(assault_rifle_S);
                break;
            case "shotgun":
                audioSrc.PlayOneShot(shotGun_S);
                break;
            case "pistol":
                audioSrc.PlayOneShot(pistol_S);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump_S);
                break;
            case "hover":
                audioSrc.PlayOneShot(hover_S);
                break;
            case "dead":
                audioSrc.PlayOneShot(death_S);
                break;
            case "zombie_attack":
                audioSrc.PlayOneShot(zombie_A_S);
                break;
            case "zombie_grunt":
                audioSrc.PlayOneShot(zombie_G_S);
                break;
            case "zombie_dead":
                audioSrc.PlayOneShot(zombie_D_S);
                break;
            case "character_damage":
                audioSrc.PlayOneShot(character_damage_S);
                break;
            case "wave":
                audioSrc.PlayOneShot(wave_S);
                break;
            case "grenade":
                audioSrc.PlayOneShot(grenade_S);
                break;
            case "cannon":
                audioSrc.PlayOneShot(cannon_S);
                break;
            case "sword":
                audioSrc.PlayOneShot(sword_S);
                break;
            case "zombie_female_attack":
                audioSrc.PlayOneShot(zombie_female_A_S);
                break;
            case "wolf_attack":
                audioSrc.PlayOneShot(wolf_A_S);
                break;
            case "Tantrum":
                audioSrc.PlayOneShot(Tantrum_S);
                break;
            case "zombie_hit":
                audioSrc.PlayOneShot(zombie_damage_S);
                break;

        }
    }
}
