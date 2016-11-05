using UnityEngine;
using System.Collections;

public class MoveTest2 : MonoBehaviour {

	public LayerMask blockingLayer;  
	public float speed;

	private Vector2 endpos;
	private bool moving = false;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2d;

	private RaycastHit2D lineHit;


	void Start () {
		
		boxCollider = GetComponent <BoxCollider2D> ();
		rb2d = GetComponent<Rigidbody2D>();

		endpos  = transform.position;
	}

	/*void Update () {
		if (moving && ((Vector2)transform.position == endpos))
			moving = false;

		if(!moving && Input.GetKeyDown(KeyCode.W)){
			moving = true;
			endpos = (Vector2)transform.position + Vector2.up;
		}

		if(!moving && Input.GetKeyDown(KeyCode.A)){
			moving = true;
			endpos = (Vector2)transform.position + Vector2.left;
		}

		if(!moving && Input.GetKeyDown(KeyCode.S)){
			moving = true;
			endpos = (Vector2)transform.position + Vector2.down;
		}

		if(!moving && Input.GetKeyDown(KeyCode.D)){
			moving = true;
			endpos = (Vector2)transform.position + Vector2.right;
		}

		rb2d.transform.position = Vector2.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
	}*/

	void Update()
	{
		//Debug.Log (transform.position + "compared to" + endpos);
		Move ();
	}

	public bool Move()
	{
		Vector2 startPos = transform.position;

		GetInputs ();

		Vector2 endPos = endpos;
		boxCollider.enabled = false;
		lineHit = Physics2D.Linecast(startPos, endPos, blockingLayer);
		boxCollider.enabled = true;

		if (lineHit.transform == null) {
			MoveRoutine (endPos);
			return true;
		} else if (lineHit.transform != null) 
		{
			endpos = transform.position; //this shit right here was so crucial
		}
		return false;


	}

	public void GetInputs()
	{
		if (moving && ((Vector2)transform.position == endpos))
			moving = false;

		if(!moving && Input.GetKeyDown(KeyCode.W)){
			Debug.Log ("pressed W");
			moving = true;
			endpos = (Vector2)transform.position + Vector2.up;
		}

		if(!moving && Input.GetKeyDown(KeyCode.A)){
			Debug.Log ("pressed A");
			moving = true;
			endpos = (Vector2)transform.position + Vector2.left;
		}

		if(!moving && Input.GetKeyDown(KeyCode.S)){
			Debug.Log ("pressed S");
			moving = true;
			endpos = (Vector2)transform.position + Vector2.down;
		}

		if(!moving && Input.GetKeyDown(KeyCode.D)){
			Debug.Log ("pressed D");
			moving = true;
			endpos = (Vector2)transform.position + Vector2.right;
		}
	}

	void MoveRoutine(Vector2 endpos)
	{
		speed = 4f;
		//Debug.Log (speed);
		rb2d.transform.position = Vector2.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
	}
}
