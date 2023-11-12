using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    GameManager theGM;

    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == transform.tag)
        {
            print("GG");
            Destroy(this.gameObject);
            // Instantiate(theGM.fruitPrefabs[0], other.transform.position, Quaternion.identity);
        }
    }
}
