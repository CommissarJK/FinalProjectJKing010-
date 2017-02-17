using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TimerControl : MonoBehaviour {
    protected bool pause = false;
    protected float timer = 0f;
    protected float speed = 0.5f;
    protected int[] date = new int[3] { 1, 1, 1000 };
    protected string[] mNames = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    protected int[] mLengths = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    protected Text dateOut;
    protected Text pauseOut;
    protected Text speedOut;
    protected float speedPips;

    void Start()
    {
        dateOut = GameObject.Find("Date").GetComponent<Text>();
        dateOut.text = date[0] + " " + mNames[date[1] - 1] + " " + date[2];

        pauseOut = GameObject.Find("Pause").GetComponent<Text>();
        if (pause)
        {
            pauseOut.text = "| |";
        }
        else
        {
            pauseOut.text = "";
        }

        speedOut = GameObject.Find("Speed").GetComponent<Text>();
        speedPips = ((0f - speed) + 3.5f) * 2f;
        string speedString = "";
        for (int i = 0; i < speedPips; i++)
        {
            speedString = speedString + "-";
        }
        speedOut.text = speedString;
    }

    void FixedUpdate()
    {
        getInput();

        if (!pause)
        {
            timer += Time.deltaTime;
            if (timer > speed)
            {
                timer = 0;
                date[0]++;
                dailyTick();
                if (date[0] > mLengths[date[1] - 1] && leapCheck())
                {
                    date[1]++;
                    date[0] = 1;
                    monthlyTick();
                    if (date[1] > 12)
                    {
                        date[2]++;
                        date[1] = 1;
                        yearlyTick();
                    }
                }
                dateOut.text = date[0] + " " + mNames[date[1] - 1] + " " + date[2];
            }
        }
    }

    protected void getInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pause = !pause;
            timer = 0f;
            if (pause)
            {
                pauseOut.text = "| |";
            }
            else
            {
                pauseOut.text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (speed > 0.5)
            {
                speed -= 0.5f;
                speedPips = ((0f - speed) + 3.5f) * 2f;
                string speedString = "";
                for (int i = 0; i < speedPips; i++)
                {
                    speedString = speedString + "-";
                }
                speedOut.text = speedString;
                //Debug.Log (speed);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (speed < 3)
            {
                speed += 0.5f;
                speedPips = ((0f - speed) + 3.5f) * 2f;
                string speedString = "";
                for (int i = 0; i < speedPips; i++)
                {
                    speedString = speedString + "-";
                }
                speedOut.text = speedString;
                //Debug.Log (speed);
            }
        }
    }

    protected bool leapCheck()
    {
        if ((date[0] != 29) || (date[1] != 2) || (date[2] % 4 != 0f))
        {
            return true;
        }
        else
        {
            Debug.Log("Leap Year");
            return false;
        }
    }

    protected void dailyTick()
    {
        //Debug.Log ("Daily Tick");
    }

    protected void monthlyTick()
    {
        Debug.Log("Monthly Tick");
    }

    protected void yearlyTick()
    {
        Debug.Log("Yearly Tick");
    }
}
