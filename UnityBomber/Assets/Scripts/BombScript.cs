using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    /// <summary>сколько кубиков сносит бомба</summary>
    public int BlastForce;

    public GameObject ExplosionPrefab;

    public Score GameMastersScore;
    
    void Start()
    {
        GameMastersScore = GameObject.FindWithTag("GameMaster").GetComponent<Score>();
    }

    //Проверка столкновений
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //столкновение с землей
        if (collision.gameObject.tag == "Ground")
        {
            CreateExplosion(this.transform.position);
            this.gameObject.SetActive(false);
        }

        //столкновение с домом
        if (collision.gameObject.tag == "HouseCub" )
        {
            
            //находим дом с которым столкнулись
            Transform house =collision.gameObject.transform.parent;
            
            //список кубов дома
           List<GameObject> houseList=new List<GameObject>();

            //проверяем не снесли ли мы дом полностью
            if (house.childCount < BlastForce + 2)
            {
                //удаляем дом полностью
                GameObject.Destroy(house.gameObject);
            }
            else
            {   //необходимо удалить только часть дома

                for (int i = 0; i < house.childCount; i++)
                {
                    //находим крышу и удаляем ее
                    if (house.GetChild(i).gameObject.tag == "HouseTop") GameObject.Destroy(house.GetChild(i).gameObject);
                    else
                    {
                        //создаем список кубов дома
                        houseList.Add(house.GetChild(i).gameObject);
                    }
                }

                //сортируем по высоте
                houseList.Sort((x, y) => y.transform.position.y.CompareTo(x.transform.position.y));

                //сохраняем координаты последнего блока
                Vector3 pos = houseList[BlastForce-1].transform.position;

                //удаляем все блоки
                for (int i = 0; i < BlastForce; i++)
                {
                    GameObject.Destroy(houseList[i]);
                }

                //на место последнего ставим поломанную крышу
                //находим крышу
                List<GameObject> houtetopdestr =
                    GameObject.FindWithTag("GameMaster").GetComponent<GameMasterScript>().HousetopDestr;


                GameObject o = Instantiate(houtetopdestr[Random.Range(0, houtetopdestr.Count - 1)], pos, Quaternion.identity);
                o.transform.parent = house;

                CreateExplosion(pos);
            }
       
            if(GameMastersScore != null)
                GameMastersScore.AddScore();


            //удаляем бомбу
            this.gameObject.SetActive(false);
        }
    }


    private void CreateExplosion(Vector3 ExpPlace)
    {
        if (ExplosionPrefab != null)
        {
            ExpPlace.z = -0.1f;
            ExpPlace.x += 0.16f;
            var expl = Instantiate(ExplosionPrefab, ExpPlace, Quaternion.identity);
        }
    }
}
