using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Object> balloonPrefabList = new List<Object>();

    private System.Random rnd = new System.Random();

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int count = rnd.Next(2) + 1;
            for (int i = 0; i < count; i++) {
                InstantiateRandomBalloon();
            }
        }
    }

    public void ExitApplication() {
        Application.Quit();
    }

    public void InstantiateRandomBalloon()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float newPosX = (float)width * (float)(rnd.NextDouble()*0.9 - 0.45f);

        Vector2 pos = new Vector2(newPosX, -height * 0.5f - 2);
        int idx = rnd.Next(balloonPrefabList.Count);

        GameObject _balloon = (GameObject)Object.Instantiate(balloonPrefabList[idx]);

        _balloon.transform.position = pos;

        BalloonController controller = _balloon.GetComponent<BalloonController>();
        controller.speed = (float)rnd.NextDouble() * 2f + 1;

        Rigidbody2D rb = _balloon.GetComponent<Rigidbody2D>();
        if (rb)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2((float)rnd.NextDouble() * 0.5f - 0.25f, controller.speed);
        }
    }
}
