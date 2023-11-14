using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCollisionCheck : MonoBehaviour
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
        theGM.collisionFlag = true;
        theGM.guideObject.SetActive(true);
        Destroy(this.GetComponent<FirstCollisionCheck>());
    }
}
