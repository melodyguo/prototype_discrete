using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Shadow> shadows;
    private bool done = false;
    private int count = 0;
    public GameObject chest;
    public GameObject confetti;
    public AudioSource sfxWin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            return;
        }

        count = 0;
        for (int i = 0; i < shadows.Count; i++)
        {
            if (shadows[i].isSafe)
            {
                count++;
            }
        }

        if (count == shadows.Count)
        {
            done = true;
            Instantiate(confetti, chest.transform);
            sfxWin.Play();
        }
    }
}
