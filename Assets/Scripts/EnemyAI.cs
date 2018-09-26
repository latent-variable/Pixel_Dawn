using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {
    public bool faceright = true;
    public bool attacking = false;
    public bool moving = false;
    private int wavenum;
	// What to chase?
	public Transform target;

	// How many times each second we will update our path
	public float updateRate = 2f;

	// Caching
	private Seeker seeker;
	private Rigidbody2D rb;

	//The calculated path
	public Path path;

	//The AI's speed per second
	public float speed = 300f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool pathIsEnded = false;

	// The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 2;

	// The waypoint we are currently moving towards
	private int currentWaypoint = 0;

  //time to next zombie grunt
  private float zombie_grunt = 45f;
  private float zombie_attack = 1.5f;
  private float time_to_sound = 0f;


	void Start () {
    wavenum = GameMaster.getwave();
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
    target = GameObject.FindGameObjectWithTag("Player").transform;
		if (target == null) {
			Debug.LogError ("No Player found? PANIC!");
			return;
		}

		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		StartCoroutine (UpdatePath ());

    time_to_sound = Time.time;
	}

	IEnumerator UpdatePath () {
		if (target == null) {
			//TODO: Insert a player search here.
			yield return false;
		}

		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds ( 1f/updateRate );
		StartCoroutine (UpdatePath());
	}

	public void OnPathComplete (Path p) {
		//Debug.Log ("We got a path. Did it have an error? " + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	void FixedUpdate () {
		if (target == null) {
			//TODO: Insert a player search here.
			return;
		}

		//TODO: Always look at player?

		if (path == null)
			return;

		if (currentWaypoint >= path.vectorPath.Count ) {
			if (pathIsEnded)
				return;


			Debug.Log ("End of path reached.");

			pathIsEnded = true;
      attacking = true;
      //Debug.Log(attacking);
			return;
		}
		pathIsEnded = false;

    if(wavenum  != GameMaster.getwave()){
        wavenum = GameMaster.getwave();
        speed += 100;
    }
		//Direction to the next waypoint
		Vector3 dir = ( path.vectorPath[currentWaypoint] - transform.position ).normalized;
		dir *= speed * Time.fixedDeltaTime;
        //Debug.Log(dir);
        SpriteRenderer flipper = gameObject.GetComponent<SpriteRenderer>();
        if(gameObject.tag == "wolf")
        {

            if (dir[0] > 0.1 && dir[0] <= 12 && !faceright)
            {
                if(dir[0] <= 11 && dir[0] >= 9.9)
                {
                    faceright = false;
                    flipper.flipX = true;
                }
                else
                {
                    faceright = true;
                    flipper.flipX = false;
                }


            }
            else if (dir[0] < 0.1 && dir[0] >= -12 && faceright)
            {
                if(dir[0] <= -9.9 && dir[0] >= -11)
                {
                    faceright = true;
                    flipper.flipX = false;
                }
                else
                {
                    faceright = false;
                    flipper.flipX = true;
                }

            }

        }
        if(dir[0] > 0.1f && dir[0] < 6 && !faceright)
        {
            faceright = !faceright;
            flipper.flipX = false;
        }
        else if (dir[0] < 0.1f && dir[0] > -6 && faceright)
        {
            faceright = !faceright;
            flipper.flipX = true;
        }
        //Move the AI
        //Debug.Log("attack here is "+ (attacking));
        if (!attacking)
        {
            rb.AddForce(dir, fMode);
            moving = true;

            if(Time.time > (time_to_sound + zombie_grunt)){
              time_to_sound = Time.time;

              if(gameObject.name == "zombie(Clone)"){
                  AudioManager.PlaySound("zombie_grunt");
              }else if(gameObject.name =="zombie_female(Clone)"){
                  AudioManager.PlaySound("zombie_female_attack");
              }else if(gameObject.name == "wolf(Clone)"){
                  AudioManager.PlaySound("wolf_attack");
              }
            }
        }
        else if (attacking)
        {
            if(Time.time > time_to_sound + zombie_attack){
              time_to_sound = Time.time;
              if(gameObject.name == "zombie(Clone)"){
                  AudioManager.PlaySound("zombie_attack");
              }else if(gameObject.name =="zombie_female(Clone)"){
                  AudioManager.PlaySound("zombie_female_attack");
              }else if(gameObject.name == "wolf(Clone)"){
                  AudioManager.PlaySound("wolf_attack");
              }

            }
            //Debug.Log("2attack here is " + (attacking));
            moving = false;
            attacking = false;
        }
		float dist = Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]);
		if (dist < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hits");
    }

}
