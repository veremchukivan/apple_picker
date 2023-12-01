using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    GameManager gameManager;
    TextMeshProUGUI scoreGT;

    private bool isMovingRight = false;
    private bool isMovingLeft = false;

    public void StartMoveRight()
    {
        isMovingRight = true;
    }

    public void StartMoveLeft()
    {
        isMovingLeft = true;
    }

    public void StopMovement()
    {
        isMovingRight = false;
        isMovingLeft = false;
    }

    void Update()
    {
        if (isMovingRight)
        {
            MoveBasketRight();
        }
        else if (isMovingLeft)
        {
            MoveBasketLeft();
        }
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreGT = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            GameObject basket = Instantiate<GameObject>(basketPrefab, pos, Quaternion.identity);
            basketList.Add(basket);
        }
    }

    void MoveBasketRight()
    {
        foreach (GameObject basketGO in basketList)
        {
            Basket basketScript = basketGO.GetComponent<Basket>();
            if (basketScript != null)
            {
                basketScript.MoveRight();
            }
        }
    }

    void MoveBasketLeft()
    {
        foreach (GameObject basketGO in basketList)
        {
            Basket basketScript = basketGO.GetComponent<Basket>();
            if (basketScript != null)
            {
                basketScript.MoveLeft();
            }
        }
    }

    public void AppleDestroyed()
    {
        foreach (GameObject tGO in GameObject.FindGameObjectsWithTag("Apple"))
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        scoreGT.text = "Score: 0";

        if (basketList.Count == 0)
        {
            gameManager.LoadGameOver();
        }
    }
}
