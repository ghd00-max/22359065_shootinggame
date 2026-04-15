using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public float spd = 5.0f;

    //public GameObject target;
    public GameObject prefabsExplosion;

    Vector3 direct = Vector3.down;
    // Start is called before the first frame update
    //private void Start()
    //{
    //    int rndNum = Random.Range(0, 10);
    //    if(rndNum % 3 == 0)
    //    {
    //        direct = target.transform.position - transform.position;
    //        direct.Normalize();
    //    }
    //}

    void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("bullet-----------------");
            GameObject gameManager = GameObject.Find("GameManager");
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
            scoreManager.nowScore++;
            scoreManager.nowScoreUI.text = "Now Score : " + scoreManager.nowScore;
            if(scoreManager.nowScore > scoreManager.bestScore)
            {
                scoreManager.bestScore = scoreManager.nowScore;
                scoreManager.bestScoreUI.text = "Best Score : " + scoreManager.bestScore;
                PlayerPrefs.SetInt("BestScore", scoreManager.bestScore);
            }

            GameObject explosionObj = Instantiate(prefabsExplosion);
            explosionObj.transform.position = transform.position;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        } else
        {
            Debug.Log("bullet-----------------");
        }
    } 
}
