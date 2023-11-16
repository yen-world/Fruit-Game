using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject guideObject;
    public bool collisionFlag;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
