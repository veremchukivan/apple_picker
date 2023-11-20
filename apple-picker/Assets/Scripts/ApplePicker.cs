using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            basketList.Add(Instantiate<GameObject>(basketPrefab, pos, Quaternion.identity));
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
