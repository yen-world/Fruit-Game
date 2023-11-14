using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    GameManager theGM;

    public GameObject respawnObject;
    GameObject fruitObject;
    public bool waitFlag;
    public bool evolutionFlag;
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        CreateFruit();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitFlag)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                waitFlag = true;
                DropFruit();
                StartCoroutine(WaitCoroutine());
            }
        }

        // if (evolutionFlag)
        // {
        //     theFM.EvolutionFruit(collisionPoint, transform.tag);
        //     evolutionFlag = false;
        // }
    }

    public void CreateFruit()
    {
        int randomNumber = Random.Range(0, 5);
        fruitObject = Instantiate(theGM.fruitPrefabs[randomNumber], respawnObject.transform.position, Quaternion.identity, respawnObject.transform);
        fruitObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void DropFruit()
    {
        theGM.guideObject.SetActive(false);
        fruitObject.GetComponent<Rigidbody2D>().isKinematic = false;
        fruitObject.transform.parent = null;
    }

    public void EvolutionFruit(Vector2 pos, string level)
    {
        print("GG");
        switch (level)
        {
            case "Cherry":
                Instantiate(theGM.fruitPrefabs[1], pos, Quaternion.identity);
                break;
            case "Strawberry":
                Instantiate(theGM.fruitPrefabs[2], pos, Quaternion.identity);
                break;
            case "Grape":
                Instantiate(theGM.fruitPrefabs[3], pos, Quaternion.identity);
                break;
            case "Lemon":
                Instantiate(theGM.fruitPrefabs[4], pos, Quaternion.identity);
                break;
            case "Persimmon":
                Instantiate(theGM.fruitPrefabs[5], pos, Quaternion.identity);
                break;
            case "Apple":
                Instantiate(theGM.fruitPrefabs[6], pos, Quaternion.identity);
                break;
            case "Pear":
                Instantiate(theGM.fruitPrefabs[7], pos, Quaternion.identity);
                break;
            case "Peach":
                Instantiate(theGM.fruitPrefabs[8], pos, Quaternion.identity);
                break;
            case "Pineapple":
                Instantiate(theGM.fruitPrefabs[9], pos, Quaternion.identity);
                break;
            case "Melon":
                Instantiate(theGM.fruitPrefabs[10], pos, Quaternion.identity);
                break;
            case "WaterMelon":
                break;
        }
    }

    public IEnumerator WaitCoroutine()
    {
        yield return new WaitUntil(() => theGM.collisionFlag);
        theGM.collisionFlag = false;
        waitFlag = false;
        CreateFruit();
    }

}
