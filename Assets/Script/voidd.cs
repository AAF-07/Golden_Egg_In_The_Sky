using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidd : MonoBehaviour
{
    public GameObject loseui;
    // Start is called before the first frame update
    void Start()
    {
        loseui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }
    }
}
