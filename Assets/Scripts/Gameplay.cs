using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    int T = 20, A = 20, I = 10, sum = 0;
    public TextMeshProUGUI txtDisplay;
    public TextMeshProUGUI txtDisplay1;
    public TextMeshProUGUI txtDisplay2;
    public float timeRemaining = 20;


    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 )
        {
            timeRemaining -= Time.deltaTime;
            txtDisplay2.text = "Time : " + timeRemaining.ToString("0");

        }
        else if (sum <= 0 )
        {
            txtDisplay1.text = "Mission Failed";
        }
 
        if (Input.GetMouseButtonDown(0))
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name.CompareTo("RedSphere") == 0)
                {
                    hit.collider.gameObject.SetActive(false);
                    sum = sum - T;
                }

                if (hit.collider.gameObject.name.CompareTo("GreenSphere") == 0)
                { 
                    hit.collider.gameObject.SetActive(false);
                    sum = sum + A;
                }

                if (hit.collider.gameObject.name.CompareTo("BlueSphere") == 0)
                {
                    hit.collider.gameObject.SetActive(false);
                    sum = sum + I;
                }
                Debug.Log(sum);
                txtDisplay.text = "Point: " + sum.ToString();
                if(sum >= 120)
                {
                    txtDisplay1.text = "Mission Completed";
                    timeRemaining = 0;
                }
                else if (sum<=0)
                {
                    txtDisplay1.text = "Mission Failed";
                    timeRemaining = 0;
                }

            }


        }
        
    }
}
