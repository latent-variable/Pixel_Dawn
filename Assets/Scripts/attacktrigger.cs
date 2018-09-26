using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacktrigger : MonoBehaviour {
    public GameObject zombie;
    //Animator anim;
    private int dmg = 10;
    private bool canatk = true;
    //public Collider2D attackingtrigger;
    private EnemyAI Aiaccess;
    private float atktime = 0;
    private float attackcd = 1f;
    private bool aiattack;
    private bool aifaceright;
    private Vector3 x = new Vector3(1.7f, -0.44f, 0f);
    private Vector3 x1 = new Vector3(-1.57f,-0.44f, 0f);

    // Use this for initialization
    void Start () {
        Aiaccess = zombie.GetComponent<EnemyAI>();
        aiattack = Aiaccess.attacking;
        aifaceright = Aiaccess.faceright;
        BoxCollider2D attackingtrigger = gameObject.GetComponent<BoxCollider2D>();
        attackingtrigger.enabled = false;
        atktime = attackcd;

        if(gameObject.tag == "wolf"){
            x = transform.localPosition;
            x1 =  new Vector3(transform.localPosition.x +1,transform.localPosition.y,transform.localPosition.z);
        }


        //Debug.Log(x1);
    }

	// Update is called once per frame
	void Update (){


        BoxCollider2D attackingtrigger = gameObject.GetComponent<BoxCollider2D>();
        Aiaccess = zombie.GetComponent<EnemyAI>();
        aiattack = Aiaccess.attacking;
        aifaceright = Aiaccess.faceright;
        //Debug.Log(aiattack);
        if (!aifaceright)
        {
            //Debug.Log(x1);
            transform.localPosition = x1;

        }
        else
        {
            transform.localPosition = x;
        }
        if (aiattack)
        {
            //Debug.Log("attacking");
            attackingtrigger.enabled = true;

            //Debug.Log(attackingtrigger.enabled);
           //Debug.Log(atktime);

            if(atktime > 0)
            {
                atktime -= Time.deltaTime;
                //Debug.Log("in");

            }
            else
            {
                attackingtrigger.enabled = false;
                atktime = attackcd;
                //Debug.Log("trigger disabled?");
                canatk = true;
            }
        }
        else
        {
            attackingtrigger.enabled = false;
        }

	}
    private void OnTriggerStay2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player_child" && aiattack)
        {
            Player_Health player = other.gameObject.GetComponent<Player_Health>();
            if (canatk)
            {
                StartCoroutine(atkdelay(3));
                //Invoke("atkdmg", 1f);
                atkdmg(other);
                canatk = false;
                //Debug.Log(canatk);
            }
        }

        //
    }
    private void atkdmg(Collider2D other)
    {

        GameObject player = other.gameObject;
        Debug.Log(player);
        Player_Health ph = player.GetComponentInParent<Player_Health>();
        Debug.Log(ph);

        //Debug.Log("dmg");
        ph.DamagePlayer(dmg);

    }
    IEnumerator atkdelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //canatk = true;
    }
}
