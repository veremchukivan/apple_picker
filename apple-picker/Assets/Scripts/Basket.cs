using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    TextMeshProUGUI scoreGT;
    ScoreKeeper scoreKeeper;
    int score = 0;
    public float moveSpeed = 5f;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreGT = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        MoveBasket();
    }

    private void MoveBasket()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += horizontalInput * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public void MoveRight()
    {
        Vector3 pos = transform.position;
        pos.x += moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public void MoveLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;
        if (collidedWith.layer == LayerMask.NameToLayer("Apples"))
        {
            Destroy(collidedWith);
            score += 100;
            scoreKeeper.ModifyScore(100);

            scoreGT.text = "Score: " + score.ToString();
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
