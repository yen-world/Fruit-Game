using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    GameManager theGM;
    GameOverCheck theGOC;

    public GameObject respawnObject;
    GameObject fruitObject;
    GameObject newFruitObject;

    public bool waitFlag;
    public bool evolutionFlag;
    public Vector2 collisionPoint;
    public string fruitLevel;


    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theGOC = FindObjectOfType<GameOverCheck>();
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

        if (evolutionFlag)
        {
            EvolutionFruit(collisionPoint, fruitLevel);
            evolutionFlag = false;
        }
    }

    public void CreateFruit()
    {
        int randomNumber = Random.Range(6, 11);
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
                newFruitObject = Instantiate(theGM.fruitPrefabs[1], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 1).ToString();
                break;
            case "Strawberry":
                newFruitObject = Instantiate(theGM.fruitPrefabs[2], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 3).ToString();
                break;
            case "Grape":
                newFruitObject = Instantiate(theGM.fruitPrefabs[3], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 6).ToString();
                break;
            case "Lemon":
                newFruitObject = Instantiate(theGM.fruitPrefabs[4], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 10).ToString();
                break;
            case "Persimmon":
                newFruitObject = Instantiate(theGM.fruitPrefabs[5], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 15).ToString();
                break;
            case "Apple":
                newFruitObject = Instantiate(theGM.fruitPrefabs[6], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 21).ToString();
                break;
            case "Pear":
                newFruitObject = Instantiate(theGM.fruitPrefabs[7], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 28).ToString();
                break;
            case "Peach":
                newFruitObject = Instantiate(theGM.fruitPrefabs[8], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 36).ToString();
                break;
            case "Pineapple":
                newFruitObject = Instantiate(theGM.fruitPrefabs[9], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 45).ToString();
                break;
            case "Melon":
                newFruitObject = Instantiate(theGM.fruitPrefabs[10], pos, Quaternion.identity);
                Destroy(newFruitObject.GetComponent<FirstCollisionCheck>());
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 55).ToString();
                break;
            case "WaterMelon":
                theGM.scoreText.text = (int.Parse(theGM.scoreText.text) + 66).ToString();
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
