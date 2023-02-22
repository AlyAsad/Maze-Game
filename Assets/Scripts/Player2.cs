using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 5f, timer = 0f;
    int seconds, moves;
    public Transform movePoint;
    public bool finished, color;
    public LayerMask whatStopsMovement;
    public GameObject GameOver, Fail, Win, Move2Point, Player;
    public TMP_Text Output;
    public SpriteRenderer SR;
    public Sprite white, black;

    // Start is called before the first frame update
    void Start()
    {
        Fail.SetActive(false);
        Win.SetActive(false);
        GameOver.SetActive(false);
        movePoint.parent = null;
        finished = false;
        moves = 1;
        color = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer);
            Output.text = "Seconds passed: " + seconds.ToString();

            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) == 0f)
            {

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * 0.7f, 0f, 0f), 0.2f, whatStopsMovement))
                    {
                        moves++;
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * 0.7f, 0f, 0f);
                    }
                }

                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * 0.7f, 0f), 0.2f, whatStopsMovement))
                    {
                        moves++;
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
        if (seconds < 10)
        {
            Win.SetActive(true);
        }
        else
        {
            Fail.SetActive(true);
        }
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (moves > 1)
        {
            moves = 0;

            if (other.gameObject.CompareTag("O1"))
            {
                Move2Point.transform.position = new Vector3(0.1f, 1.4f, 0f);
                Player.transform.position = new Vector3(0.1f, 1.4f, 0f);
            }

            else if (other.gameObject.CompareTag("O2"))
            {
                Move2Point.transform.position = new Vector3(0.1f, -1.4f, 0f);
                Player.transform.position = new Vector3(0.1f, -1.4f, 0f);
            }

            else if (other.gameObject.CompareTag("G1"))
            {
                Move2Point.transform.position = new Vector3(2.9f, 0f, 0f);
                Player.transform.position = new Vector3(2.9f, 0f, 0f);
            }

            else if (other.gameObject.CompareTag("G2"))
            {
                Move2Point.transform.position = new Vector3(2.9f, 1.4f, 0f);
                Player.transform.position = new Vector3(2.9f, 1.4f, 0f);
            }

        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (color)
        {
            SR.sprite = black;
        }

        else
        {
            SR.sprite = white;
        }
        color = !color;
    }

}
