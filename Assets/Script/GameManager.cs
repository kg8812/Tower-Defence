using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;
    public static GameManager Instance { get; private set; } 

    private void Awake()
    {
        Instance = this;
        gold = 600;
    }

    int gold;

    public int Gold => gold;

    private void Update()
    {
        goldText.text = gold.ToString();
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }
}
