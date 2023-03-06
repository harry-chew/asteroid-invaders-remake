using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameTextScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.StartCoroutine("GameStart");
            Destroy(gameObject);
        }
    }
}
