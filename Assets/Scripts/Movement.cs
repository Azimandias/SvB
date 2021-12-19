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

    void Start()
    {
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
        /*if (collision.collider.TryGetComponent(out BadSector badSector))
        {
            HP--;
            playerHPvisualise.UpdateVisualisation();

            badSector.BadSectorHP--;
            badSector.UpdateBadSectorHP();

            if (HP == 0)
            {
                Debug.Log("game over");
            }

            if (badSector.BadSectorHP == 0)
            {
                Destroy(collision.gameObject);
            }
        }*/

        if (collision.collider.TryGetComponent(out CirleOfLife eat))
        {           
            Points += eat.bonus;
            PointsText.text = Points.ToString();
            Destroy(eat.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        Head.velocity = new Vector3(sidewaysSpeed * 5, Speed);

        sidewaysSpeed = 0;
    }

}