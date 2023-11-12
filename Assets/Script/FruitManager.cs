using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    GameManager theGM;
    RespownManager theRM;

    public GameObject respawnObject;
    GameObject fruitObject;
    public bool waitFlag;

    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theRM = FindObjectOfType<RespownManager>();
        CreateFruit();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitFlag)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                waitFlag = !waitFlag;
                DropFruit();
                StartCoroutine(WaitCoroutine());
            }
        }
    }

    public void CreateFruit()
    {
        int randomNumber = Random.Range(0, 5);
        fruitObject = Instantiate(theGM.fruitPrefabs[randomNumber], respawnObject.transform.position, Quaternion.identity, respawnObject.transform);
        fruitObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void DropFruit()
    {
        fruitObject.GetComponent<Rigidbody2D>().isKinematic = false;
        fruitObject.transform.parent = null;
    }

    public IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        CreateFruit();
        waitFlag = !waitFlag;
    }

}
