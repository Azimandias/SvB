using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Movement Points;
    private void Start()
    {
        int points = PlayerPrefs.GetInt("Points");
        //Movement.Points.PointsText = points.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }
}
