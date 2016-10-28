using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.IO.Ports;

public class SerialCommand : MonoBehaviour
{
    SerialPort port;
    public string COMPort; //com arduino that I'm using
    string[] Numbers = new string[2]; //Numbers data
    // Use this for initialization
    void Start()
    {
        port = new SerialPort(COMPort, 9600); //setting up serial port

        if (port.IsOpen) //opens the port
        {
            port.Close();
            port.Open();
        }
        else
        {
            port.Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (port.IsOpen) //if the port is open
        {
            Numbers = port.ReadLine().Split(','); //putting the data from arduino in a variable
        }

        if ((float)Int16.Parse(Numbers[1]) >= 600) //if joystick is to the left
        {
            print("left");
        }

        if ((float)Int16.Parse(Numbers[1]) <= 400) //if joystick is enough to the right
        {
            print("right");
        }

        if ((float)Int16.Parse(Numbers[0]) >= 600) //if joystick is getting vertically down
        {
            print("down");
        }

        if ((float)Int16.Parse(Numbers[0]) <= 400) //if joystick is getting vertically up
        {
            print("up");
        }
    }
}