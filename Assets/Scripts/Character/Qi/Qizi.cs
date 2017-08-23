using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qizi : MonoBehaviour {
    public bool ColorState; // white: true, black: false
    private List<bool> AdjacentStatus = new List<bool>();
    private List<RaycastHit2D> BoundaryRays;
    private float RayDistance = 1.1f;
    public enum Direction{
        up,
        down,
        left,
        right
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 4; i++)
        {
            AdjacentStatus.Add(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i =0; i < 4; i++)
        {
            if(AdjacentStatus[i] == false)
            {
                break;
   
            }
            if (AdjacentStatus[3] == true)
            {
                Destroy(this.gameObject);
            }
        }
	}

    private void FixedUpdate()
    {
        for (int i=0; i<4; i++)
        {
            Direction Curr_Dir = (Direction)i;
            RaycastHit2D[] hits;
            switch (Curr_Dir)
            {
                case Direction.up:
                    hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.up, RayDistance); 
                    foreach(RaycastHit2D hit in hits)
                    {
                        if(hit.collider.gameObject != this.gameObject)
                        {
                            print(this.gameObject + " Up has " + hit.collider.gameObject);
                            AdjacentStatus[(int)Direction.up] = true;
                            break;
                        }
                    }
                    AdjacentStatus[(int)Direction.up] = false;
                    break;
                case Direction.down:
                    hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), -Vector2.up, RayDistance);
                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.collider.gameObject != this.gameObject)
                        {
                            print(this.gameObject + " Down has " + hit.collider.gameObject);
                            AdjacentStatus[(int)Direction.down] = true;
                        }
                    } 
                    AdjacentStatus[(int)Direction.down] = false;
                    break;
                case Direction.left:
                    hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.left, RayDistance);
                    Debug.DrawRay(transform.position, Vector2.left, Color.green, 2, false);
                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.collider.gameObject != this.gameObject)
                        {
                            print(this.gameObject + " Left has " + hit.collider.gameObject);
                            AdjacentStatus[(int)Direction.left] = true;
                        }  
                    }
                    AdjacentStatus[(int)Direction.left] = false;
                    break;
                case Direction.right:
                    hits = Physics2D.RaycastAll(transform.position, -Vector2.left, RayDistance);
                    Debug.DrawRay(transform.position, -Vector2.left, Color.green, 2, false);
                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.collider.gameObject != this.gameObject)
                        {
                            print(this.gameObject + " Right has " + hit.collider.gameObject);
                            AdjacentStatus[(int)Direction.right] = true;
                        } 
                    }
                    AdjacentStatus[(int)Direction.right] = false;
                    break;
            }
        }
    }
}
