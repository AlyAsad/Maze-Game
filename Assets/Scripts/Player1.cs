using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player1 : MonoBehaviour
{
    public int Counter;
    public float moveSpeed = 5f;
    public Transform movePoint;
    public bool finished;
    public LayerMask whatStopsMovement;
    public GameObject GameOver, Fail, Win;
    public TMP_Text Output;

    System.Random rnd = new System.Random();
    int index, index2;
    public GameObject Player, MovePoint, Stone, Lava, Goal;
    public List<Vector3> PlayerSpawn, ItemSpawn, GoalSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Fail.SetActive(false);
        Win.SetActive(false);
        GameOver.SetActive(false);
        movePoint.parent = null;
        finished = false;
        Counter = 0;

        PlayerSpawn = new List<Vector3>{new Vector3(0.1f, -1.4f, 0f), new Vector3(0.8f, -1.4f, 0f),
            new Vector3(1.5f, -1.4f, 0f), new Vector3(2.2f, -1.4f, 0f),  new Vector3(2.9f, -1.4f, 0f)};

        index = rnd.Next(5);
        MovePoint.transform.position = PlayerSpawn[index];
        Player.transform.position = PlayerSpawn[index];

        GoalSpawn = new List<Vector3>{new Vector3(0.1f, 1.4f, 0f), new Vector3(0.8f, 1.4f, 0f),
            new Vector3(1.5f, 1.4f, 0f), new Vector3(2.2f, 1.4f, 0f),  new Vector3(2.9f, 1.4f, 0f)};

        index = rnd.Next(5);
        Goal.transform.position = GoalSpawn[index];


        ItemSpawn = new List<Vector3>{new Vector3(0.1f, -0.7f, 0f), new Vector3(0.8f, -0.7f, 0f), new Vector3(1.5f, -0.7f, 0f),
            new Vector3(2.2f, -0.7f, 0f), new Vector3(2.9f, -0.7f, 0f), new Vector3(0.1f, 0f, 0f), new Vector3(0.8f, 0f, 0f), new Vector3(1.5f, 0f, 0f),
            new Vector3(2.2f, 0f, 0f), new Vector3(2.9f, 0f, 0f), new Vector3(0.1f, 0.7f, 0f), new Vector3(0.8f, 0.7f, 0f), new Vector3(1.5f, 0.7f, 0f),
            new Vector3(2.2f, 0.7f, 0f), new Vector3(2.9f, 0.7f, 0f)};

        index = rnd.Next(15);

        do
        {
            index2 = rnd.Next(15);
        } while (index2 == index);

        Stone.transform.position = ItemSpawn[index];
        Lava.transform.position = ItemSpawn[index2];

    }

    // Update is called once per frame
    void Update()
{
        if (!finished)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) == 0f)
            {

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * 0.7f, 0f, 0f), 0.2f, whatStopsMovement))
                    {
                        Counter++;
                        Output.text = "Moves made: " + Counter.ToString();
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * 0.7f, 0f, 0f);
                    }
                }

                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * 0.7f, 0f), 0.2f, whatStopsMovement))
                    {
                        Counter++;
                        Output.text = "Moves made: " + Counter.ToString();
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * 0.7f, 0f);
                    }
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Die();
        }

        else if (collision.gameObject.CompareTag("Flag"))
        {
            Ended();
        }
    }

    public void Die()
    {
        finished = true;
        GameOver.SetActive(true);

    }

    public void Ended()
    {
        finished = true;
        if (Counter > 10)
        {
            Fail.SetActive(true);
        }
        else
        {
            Win.SetActive(true);
        }

    }

}
