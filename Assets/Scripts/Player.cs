using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] TMP_Text scoreText;

    private int score = 0;
    [SerializeField] private float health = 100f;

    public int Score {
        get { return score; }
        set { score = value; scoreText.text = "Score: " + score.ToString();  }
    }
    public float Health { get { return health; } set {  health = value; } }

    public void addPoints(int points) {
        Score += points;
    }
}
