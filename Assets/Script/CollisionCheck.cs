using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    GameManager theGM;
    FruitManager theFM;


    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theFM = FindObjectOfType<FruitManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == transform.tag)
        {
            theFM.evolutionFlag = true;
            ContactPoint2D contact = other.contacts[0];
            theFM.collisionPoint = contact.point;
            theFM.fruitLevel = transform.tag;
            Destroy(this.gameObject);
        }
    }
}
