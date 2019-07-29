﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class ClickLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private CarController m_Car; // the car controller we want to use
        public static float turn = 0;
        private bool timeDone;
        public static bool hoverMouse = false;
        private bool isIn;
        public static bool left_clicked;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void FixedUpdate()
        {
            IEnumerator Example()
            {
                timeDone = false;
                yield return new WaitForSeconds((float)0.2);
                timeDone = true;
            }
            if (isIn)
            {
                ////debug.log("entered is in");
                if (move.correct_input)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ////debug.log("Mouse down");
                        move.TURNING = -2;
                        left_clicked = true;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        move.TURNING = 0;
                        left_clicked = false;
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ////debug.log("Mouse down");
                        move.TURNING = 2;
                        left_clicked = true;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        move.TURNING = 0;
                        left_clicked = false;
                    }
                }
            }
        }
        //else
        //{
        //   if (Input.GetMouseButtonDown(0))
        //   {
        //       ////debug.log("Mouse down");
        //       move.TURNING = 2;
        //   }
        //   else if (Input.GetMouseButtonUp(0))
        //   {
        //      move.TURNING = 0;
        //  }
        //}
        public void OnPointerEnter(PointerEventData eventData)
        {
            ////debug.log("Mouse enter");
            isIn = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ////debug.log("Mouse exit");
            isIn = false;
        }
    }
}
