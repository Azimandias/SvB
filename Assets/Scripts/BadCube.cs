using TMPro;
using UnityEngine;

public class BadCube : MonoBehaviour
{
    public int bonus;
    public TextMeshPro bonusText;

    private void Start()
    {
        bonusText.text = bonus.ToString();
    }

    public void BadCubePoints()
    {
        bonusText.text = bonus.ToString();
    }

}

