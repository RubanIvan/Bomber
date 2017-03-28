using System.Collections;

using System.Collections.Generic;


using UnityEngine;


public struct GameLevel
{
    public int MaxHeight;
    public int MinHeight;
    public Vector2 FinishPos;

}

[RequireComponent(typeof(AudioSource))]
public class GameMasterScript : MonoBehaviour {

    
    /// <summary>список целых крыш </summary>
    public List<GameObject> HousetopNormal =new List<GameObject>();

    /// <summary>список разрушенных "крыш" </summary>
    public List<GameObject> HousetopDestr =new List<GameObject>();

    /// <summary>список кубов из которых строятся дома </summary>
    public List<GameObject> HouseCub = new List<GameObject>();

    /// <summary>префаб бомбы</summary>
    public GameObject BombPrefab;

    /// <summary>префаб игрока</summary>
    public GameObject PlayerPrefab;

    /// <summary>список с параметрами для уровней</summary>
    public List<GameLevel> GameLevel=new List<GameLevel>();

    /// <summary>текущий уровень </summary>
    public int CurGameLevel = 0;

    /// <summary>ссылка на корневой узел домов</summary>
    public GameObject HouseRoot;

    // Use this for initialization
    void Start () {
        GenerateLevel();

        

    }
	
    /// <summary>Генерация уровня в зависимости от CurGameLevel</summary>
    void GenerateLevel()
    {
        //ссылка на тип дома (цвет)
        GameObject houseCub;

        //текущий кубик для дома
        GameObject o;

        //ссылка на текущий дом
        GameObject h;

        //удаляем все старые дома перед созданием уровня
        GameObject.Destroy(HouseRoot);
        HouseRoot = new GameObject("HouseRoot");

        for (int i = -5; i < 5; i++)
        {
            //высота дома
            int houseHeight = Random.Range(GameLevel[CurGameLevel].MinHeight, GameLevel[CurGameLevel].MaxHeight);

            //создаем контейнер для дома
            h = new GameObject("House " + i);
            h.transform.parent = HouseRoot.transform;

            //выбираем какого типа будет дом
            houseCub = HouseCub[Random.Range(0, HouseCub.Count - 1)];

            for (int j = 0; j < houseHeight; j++)
            {
                //создаем дом
                o = Instantiate(houseCub, new Vector3(0.32f * i, 0.32f * j - 3.2f), Quaternion.identity);
                o.transform.parent = h.transform;
            }
            //ставим на него любую доступную крышу
            o = Instantiate(HousetopNormal[Random.Range(0, HousetopNormal.Count - 1)], new Vector3(0.32f * i, 0.32f * houseHeight - 3.2f), Quaternion.identity);
            o.transform.parent = h.transform;

        }

    }


    void Awake()
    {
        GameLevel.Add(new GameLevel() {MaxHeight = 15,MinHeight = 5,FinishPos = new Vector2(-100,100)});
        GameLevel.Add(new GameLevel() { MaxHeight = 10, MinHeight = 5, FinishPos = new Vector2(-100, 100) });
        GameLevel.Add(new GameLevel() { MaxHeight = 15, MinHeight = 10, FinishPos = new Vector2(-100, 100) });
    }

}
