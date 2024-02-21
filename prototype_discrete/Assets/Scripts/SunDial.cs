using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunDial : MonoBehaviour
{
    public List<GameObject> sunPath;
    public Slider sunDial;
    public GameObject sun;
    public GameObject shadow1;
    public GameObject shadow2;
    public GameObject shadow3;
    public GameObject shadow4;
    public GameObject shadow5;
    private int lastValue;
    
    // Start is called before the first frame update
    void Start()
    {
        lastValue = 0;
        shadow1.SetActive(true);
        shadow2.SetActive(false);
        shadow3.SetActive(false);
        shadow4.SetActive(false);
        shadow5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastValue != sunDial.value)
        {
            lastValue = (int) sunDial.value;
            updateDial();
        }
    }

    void updateDial()
    {
        sun.transform.position = sunPath[(int) sunDial.value].transform.position;
        shadow1.SetActive(false);
        shadow2.SetActive(false);
        shadow3.SetActive(false);
        shadow4.SetActive(false);
        shadow5.SetActive(false);
        
        switch ((int) sunDial.value)
        {
            case 0:
            {
                shadow1.SetActive(true);
                break;
            }
            case 1:
            {
                shadow2.SetActive(true);
                break;
            }
            case 2:
            {
                shadow3.SetActive(true);
                break;
            }
            case 3:
            {
                shadow4.SetActive(true);
                break;
            }
            case 4:
            {
                shadow5.SetActive(true);
                break;
            }
        }
    }
}
