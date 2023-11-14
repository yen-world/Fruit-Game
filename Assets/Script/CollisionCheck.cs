using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    GameManager theGM;
    FruitManager theFM;

    Vector2 collisionPoint;
    public bool evolutionFlag;
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
            evolutionFlag = true;
            ContactPoint2D contact = other.contacts[0];
            collisionPoint = contact.point;
            theFM.EvolutionFruit(collisionPoint, transform.tag);
            print("GG");
            Destroy(this.gameObject);
        }
    }
}
