using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private GameObject p;
    private Player player;
    // Start is called before the first frame update

    void Start()
    {

        p = GameObject.FindWithTag("Player");
        player = p.GetComponent<Player>();
    }
    public void Restart()
    {
        player.hp = 100;
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
