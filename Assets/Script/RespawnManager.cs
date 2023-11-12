using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RespownManager : MonoBehaviour
{
    GameManager theGM;
    FruitManager theFM;

    public GameObject respawnObject;
    public Vector2 vector;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theFM = FindObjectOfType<FruitManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (transform.position.x >= -2.35f && transform.position.x <= 2.35f)
            {
                vector.Set(Input.GetAxisRaw("Horizontal"), 0);
                transform.Translate(vector * speed * Time.deltaTime);

                if (transform.position.x < -2.35f)
                {
                    vector.Set(-2.35f, transform.position.y);
                    transform.position = vector;
                }
                else if (transform.position.x > 2.35f)
                {
                    vector.Set(2.35f, transform.position.y);
                    transform.position = vector;
                }
            }
        }
    }

}
