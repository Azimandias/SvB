using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Movement movement;
    public Text scoreText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = movement.PointsText.text;
    }
}
