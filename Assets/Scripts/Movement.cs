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
<<<<<<< Updated upstream

    public SnakeTail componentSnakeTail;
    private Vector3 PreviousMousePosition;
    private float sidewaysSpeed;



   // public float boulForce = 5f;



    void Start()
    { 
=======
    public Game Game;
    public SnakeTail componentSnakeTail;
    private Vector3 PreviousMousePosition;
    private float sidewaysSpeed;
    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        
>>>>>>> Stashed changes
        for (int i = 0; i < Points; i++) componentSnakeTail.AddCircle();
        PointsText.text = Points.ToString();
    }

    void FixedUpdate() //Update()
    {       
        transform.position += transform.forward * Speed * Time.deltaTime;

<<<<<<< Updated upstream
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
=======
                if (Input.GetMouseButton(0))
                {
                    Vector3 delta = Input.mousePosition - PreviousMousePosition;
                    Head.AddForce(delta.x * Sensitivity, 0, 0);
                }
                else if (Input.GetMouseButton(0))
                {
                    MooveForward();
                }



        PreviousMousePosition = Input.mousePosition;
>>>>>>> Stashed changes
    }

    public void OnCollisionStay(Collision collision)
    {

        if (collision.collider.TryGetComponent(out BadCube badSector))
        {
<<<<<<< Updated upstream
            for (int i = 0; i < badSector.bonus; i++)
=======
            
            if((Points > 0))
            {
                Points--;
                badSector.bonus--;
                componentSnakeTail.RemoveCircle();
                audioData.Play();
                PointsText.text = Points.ToString();
                badSector.BadCubePoints();
            }          

            else if (Points <= 0)
>>>>>>> Stashed changes
            {
                Points--;
                badSector.bonus--;
                componentSnakeTail.RemoveCircle();
                PointsText.text = Points.ToString();
                badSector.BadCubePoints();

                if (Points == 0)
                {
                    Debug.Log("game over");
                }

<<<<<<< Updated upstream
                if (badSector.bonus == 0)
                {
                    Destroy(badSector.gameObject);
                }
            }
=======
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
>>>>>>> Stashed changes
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
        Head.velocity = new Vector3(sidewaysSpeed * 5, Speed);

        sidewaysSpeed = 0;
    }

}
