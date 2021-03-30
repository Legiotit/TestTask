using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int score { get; private set; }

    [SerializeField]
    GameObject tilePrefab;
    [SerializeField]
    GameObject money;
    [SerializeField]
    GameObject HeroPrefab;

    GameObject LevelMoney;
    GameObject LevelTile;

    [SerializeField]
    Vector3 StartPosHero;

    [SerializeField]
    LoadLevel loadLevel;

    [SerializeField]
    Text scoreText;

    private void Start()
    {
        StartLevel(Random.Range(15,20),20,20);
    }


    public void StartLevel(int numberMoney, int length, int width)
    {
        GenerateWorld(width, length);
        GenerateMoney(numberMoney, width, length);
        StartPosHero = new Vector3(width / 2, 3, length / 2);
        BackHeroStaptPos();
    }

    private void GenerateWorld(int length, int width)
    {
        LevelTile = Instantiate(new GameObject(), new Vector3(0, 0), new Quaternion(), transform);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(i, 0, j), new Quaternion(), LevelTile.transform);
                if ((i + j) % 2 == 0)
                {
                    tile.GetComponent<Renderer>().material.color = Color.white;
                }
                else
                {
                    tile.GetComponent<Renderer>().material.color = Color.black;
                }
            }
        }
    }

    private void GenerateMoney(int numberMoney, int length, int width)
    {
        bool[,] map = new bool[width, length];
        LevelMoney = Instantiate(new GameObject(), new Vector3(0, 0), new Quaternion(), transform);
        numberMoney = width * length > numberMoney ? numberMoney : width * length;
        for (int i = 0; i < numberMoney; i++)
        {
            int x = 0;
            int y = 0;
            while (true)
            {
                x = Random.Range(0, width);
                y = Random.Range(0, length);
                if (!map[x, y])
                {
                    GameObject newMoney = Instantiate(money, new Vector3(x + 0.5f, 0.3f, y + 0.5f),new Quaternion(), LevelMoney.transform);
                    newMoney.transform.GetComponent<Money>().Level = this;
                    break;
                }
            }
        }
    }

    private void Update()
    {
        if (scoreText!= null)
        {
            scoreText.text = score.ToString();
        }

        if (HeroPrefab != null && HeroPrefab.transform.position.y < -10)
        {
            BackHeroStaptPos();
        }

        if (!CheckMoney())
        {
            EndLevel();
        }
    }

    public bool CheckMoney()
    {
        return LevelMoney.transform.childCount > 0;
    }

    public void AddMoney()
    {
        score++;
    }

    public void EndLevel()
    {
        UserData.score += score;
        UserData.SaveUserDataScore();
        loadLevel.LoadScene(0);
    }

    public void BackHeroStaptPos()
    {
        if (HeroPrefab != null) 
        {
            HeroPrefab.transform.position = StartPosHero;
            HeroPrefab.transform.rotation = new Quaternion();
        }
        
    }
}
