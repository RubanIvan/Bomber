using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    /// <summary>Скорость движения</summary>
    public float SpeedX;

    public float SpeedY;

    public GameObject BombaPrefab;

    private GameObject BombaCurent;
    private Vector3 pos;

    /// <summary>Координаты конца экрана</summary>
    private float BorderPosition;

    /// <summary>размеры спрайта  </summary>
    private float SpriteSize;

    // Use this for initialization
    void Start()
    {

        GameObject MainCamera = GameObject.FindWithTag("MainCamera");
        Vector3 v = MainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(-1, -1));
        BorderPosition = Mathf.Abs(v.x);

        SpriteSize = GetComponent<SpriteRenderer>().sprite.rect.width;

        BombaCurent = Instantiate(BombaPrefab);
        BombaCurent.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        pos = transform.position;
        pos.x += SpeedX * Time.deltaTime;
        transform.position = pos;


        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") ||
            Input.GetButtonDown("Jump"))
        {
            //разрешаем пулять только одну бомбу и только в экране
            if (BombaCurent.activeSelf == false && transform.position.x > -BorderPosition)
            {
                BombaCurent.transform.position = this.transform.position;
                BombaCurent.transform.rotation = Quaternion.identity;
                BombaCurent.transform.Rotate(0, 0, Random.Range(-15, 15));
                BombaCurent.SetActive(true);
            }
        }


        //определяем улители ли мы за границу экрана
        if (transform.position.x > BorderPosition)
        {
            //улители за экран
            //выполняем снижение
            pos = transform.position;
            pos.y -= SpeedY;
            //перетаскиваем в левый угол
            pos.x = -BorderPosition - SpriteSize / 100f - 0.1f;
            transform.position = pos;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       //столкновение с землей
        if (collision.gameObject.tag == "HouseCub")
        {
            SceneManager.LoadScene(0);
        }

    }
}