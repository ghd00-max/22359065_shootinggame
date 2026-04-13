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
        GameObject explosionObi = Instantiate(prefabsExplosion);
        explosionObi.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
