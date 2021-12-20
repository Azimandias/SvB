using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 2;
    public float Sensitivity = 5;
    public int Points = 5;
    public Rigidbody Head;
    public TextMeshPro PointsText;

    public SnakeTail componentSnakeTail;
    private Vector3 PreviousMousePosition;
    private float sidewaysSpeed;



    public float boulForce = 5f;



    void Start()
    { 
        for (int i = 0; i < Points; i++) componentSnakeTail.AddCircle();

        PointsText.text = Points.ToString();
    }

    void Update()
    {       
        transform.position += transform.forward * Speed * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - PreviousMousePosition;
            Head.AddForce(delta.x * Sensitivity, 0, 0);
        }

        PreviousMousePosition = Input.mousePosition;


        if (Input.GetKeyDown(KeyCode.A))
        {
            Points++;
            componentSnakeTail.AddCircle();
            PointsText.SetText(Points.ToString());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Points--;
            componentSnakeTail.RemoveCircle();
            PointsText.SetText(Points.ToString());
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out BadCube badSector))
        {
            for (int i = 0; i < badSector.bonus; i++)
            {
                Boul();
                Points --;
                badSector.bonus--;
                componentSnakeTail.RemoveCircle();
                PointsText.text = Points.ToString();
                badSector.BadCubePoints();
            }

            if (Points == 0)
            {
                Debug.Log("game over");
            }

            if (badSector.bonus == 0)
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
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        Head.velocity = new Vector3(sidewaysSpeed * 5, Speed);

        sidewaysSpeed = 0;
    }

    public async void Boul()
    {
        Head.AddForce(new Vector3(0, 0, -boulForce), ForceMode.Impulse);
        await Task.Delay(150);
        //MooveForward();
    }

}
