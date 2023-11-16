using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCollisionCheck : MonoBehaviour
{
    GameManager theGM;
    CollisionCheck theCC;

    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theCC = FindObjectOfType<CollisionCheck>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        theGM.collisionFlag = true;
        theGM.guideObject.SetActive(true);
        theCC.dropCompleteFlag = true;
        Destroy(this.GetComponent<FirstCollisionCheck>());
    }
}
