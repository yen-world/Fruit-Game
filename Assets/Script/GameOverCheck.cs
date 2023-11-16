using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CollisionCheck>().dropCompleteFlag)
        {
            print("게임 오버");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }

}
