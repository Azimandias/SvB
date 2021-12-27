using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 8f;
    public float Sensitivity = 10f;
    public int Points = 10;
    public Rigidbody Head;
    public TextMeshPro PointsText;
    public Game Game;

    public SnakeTail componentSnakeTail;
    private Vector3 PreviousMousePosition;
    private float sidewaysSpeed;

    void Start()
    {
        for (int i = 0; i < Points; i++) componentSnakeTail.AddCircle();

        PointsText.text = Points.ToString();
    }

    void FixedUpdate() //Update()
    {
        MooveForward();

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - PreviousMousePosition;
            Head.AddForce(delta.x * Sensitivity, 0, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            sidewaysSpeed = 0;           
        }
        PreviousMousePosition = Input.mousePosition;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out BadCube badSector))
        {
            Points--;
            badSector.bonus--;
            componentSnakeTail.RemoveCircle();
            PointsText.text = Points.ToString();
            badSector.BadCubePoints();

            if (Points <= 0)
            {
                Speed = 0;
                Game.OnSnakeDied();
            }

            if (badSector.bonus <= 0)
            {
                Destroy(badSector.gameObject);
            }           
        }

            if (collision.collider.TryGetComponent(out CirleOfLife eat))
            {
                for (int i = 0; i < eat.bonus; i++)
                {
                    Points++;
                    componentSnakeTail.AddCircle();
                    PointsText.text = Points.ToString();
                }
                Destroy(eat.gameObject);
            }

            if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
            Head.velocity = new Vector3(sidewaysSpeed * 10, 0, Speed);

            sidewaysSpeed = 0;
        }
   
        public void MooveForward()
        {
            Head.AddForce(Vector3.forward * Speed);
        }
    }
