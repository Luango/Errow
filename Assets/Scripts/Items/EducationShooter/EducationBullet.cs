﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationBullet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hi collision");
        print(collision.tag);
        if (collision.tag == "Player" || collision.tag == "Others")
        {
            print("hi player");
            Destroy(this.gameObject);
        }
        if (collision.tag == "People")
        {
            SpriteSlicer2D.ExplodeSprite(collision.GetComponent<Rigidbody2D>().gameObject, 5, 15.0f, true, ref SpriteSlicer2DDemoManager.m_SlicedSpriteInfo);
            // If we've chosen to fade out fragments once an object is destroyed, add a fade and destroy component
            for (int spriteIndex = 0; spriteIndex < SpriteSlicer2DDemoManager.m_SlicedSpriteInfo.Count; spriteIndex++)
            {
                for (int childSprite = 0; childSprite < SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects.Count; childSprite++)
                {
                    if (!SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].GetComponent<Rigidbody2D>().isKinematic)
                    {
                        SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].layer = LayerMask.NameToLayer("Apple");
                        SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].AddComponent<FadeAndDestroy>();
                    }
                }
            }
            SpriteSlicer2DDemoManager.m_SlicedSpriteInfo.Clear();
        }
        Destroy(this.gameObject);
    }

    private float BulletSpeed = 30f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up* Time.deltaTime* BulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string _tag = collision.gameObject.tag;
        if (_tag == "People")
        {
            SpriteSlicer2D.ExplodeSprite(collision.rigidbody.gameObject, 5, 15.0f, true, ref SpriteSlicer2DDemoManager.m_SlicedSpriteInfo);
            // If we've chosen to fade out fragments once an object is destroyed, add a fade and destroy component
            for (int spriteIndex = 0; spriteIndex < SpriteSlicer2DDemoManager.m_SlicedSpriteInfo.Count; spriteIndex++)
            {
                for (int childSprite = 0; childSprite < SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects.Count; childSprite++)
                {
                    if (!SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].GetComponent<Rigidbody2D>().isKinematic)
                    {
                        SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].layer = LayerMask.NameToLayer("Apple");
                        SpriteSlicer2DDemoManager.m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].AddComponent<FadeAndDestroy>();
                    }
                }
            }
            SpriteSlicer2DDemoManager.m_SlicedSpriteInfo.Clear();
            Destroy(this.gameObject);
        }
    }
}
