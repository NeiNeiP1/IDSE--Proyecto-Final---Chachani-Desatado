using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEGINING : MonoBehaviour
{
    public GameObject cutsceneCam, player;
    public float cutsceneTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cutscene());


    }
    IEnumerator cutscene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
