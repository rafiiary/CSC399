﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class changing_the_turn : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public GameObject input_destination;
        private TMP_Text text;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            ////print("H" + (h * 10000).ToString());
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            ////print("V" + v.ToString());
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            if (input_destination.transform.childCount > 0)
            {
                //m_Car.Move(h, v, v, handbrake);
                ////print(input_destination.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text);
                text = input_destination.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
                ////debug.log("THE CAR MAX SPEED CHOSEN IS " + m_Car.m_Topspeed.ToString());
                if (text.text == "nothing")
                    {
                    m_Car.Move(0, v, v, 0);
                }
            }
            else
            {
                m_Car.Move(0, 0, 0, 0);
            }
#else
            //m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
