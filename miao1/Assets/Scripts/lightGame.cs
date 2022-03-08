using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightGame : MonoBehaviour
{
    public List<GameObject> lights = new List<GameObject>();
    public List<bool> b = new List<bool>();
    public bool finish;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<lights.Count; i++)
        {
            if(lights[i].GetComponent<Image>().color.a == 0)
            {
                b[i] = false;
            }
            if(lights[i].GetComponent<Image>().color.a == 1)
            {
                b[i] = true;
            }
        }
        if(!b.Contains(false))
        {
            finish = true;
            for(int i=0; i<lights.Count; i++)
            {
                lights[i].GetComponent<Button>().enabled = false;
                target.SetActive(true);
                this.GetComponent<lightGame>().enabled = false;
            }
        }
        if(((GameManager.instance.player.transform.position - this.transform.position).magnitude >= 50) && !finish)
        {
            resetLights();
        }
    }
    public void hit(int l)
    {
        if(l == 0)
        {
            turn(lights[0]);
            turn(lights[1]);
            turn(lights[3]);
        }
        if(l == 1)
        {
            turn(lights[0]);
            turn(lights[1]);
            turn(lights[2]);
            turn(lights[4]);
        }
        if(l == 2)
        {
            turn(lights[2]);
            turn(lights[1]);
            turn(lights[5]);
        }
        if(l == 3)
        {
            turn(lights[0]);
            turn(lights[4]);
            turn(lights[6]);
            turn(lights[3]);
        }
        if(l == 4)
        {
            turn(lights[1]);
            turn(lights[3]);
            turn(lights[4]);
            turn(lights[5]);
            turn(lights[7]);
        }
        if(l == 5)
        {
            turn(lights[2]);
            turn(lights[4]);
            turn(lights[5]);
            turn(lights[8]);
        }
        if(l == 6)
        {
            turn(lights[6]);
            turn(lights[1]);
            turn(lights[3]);
        }
        if(l == 7)
        {
            turn(lights[6]);
            turn(lights[7]);
            turn(lights[8]);
            turn(lights[4]);
        }
        if(l == 8)
        {
            turn(lights[7]);
            turn(lights[8]);
            turn(lights[5]);
        }
    }
    void turn(GameObject obj)
    {
        if(obj.GetComponent<Image>().color.a == 0)
        {
            obj.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        }else{
            obj.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        }
    }
    public async void resetLights()
    {
        for(int i = 0; i<lights.Count; i++)
        {
            lights[i].GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        }
        lights[8].GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
    }
}
