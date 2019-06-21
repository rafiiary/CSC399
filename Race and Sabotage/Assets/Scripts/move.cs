﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class move : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public GameObject drop1;
        public GameObject drop2;
        public GameObject dragAndDropCanvas;
        public static bool correct_input = false;
        bool right = false;
        public GameObject countdown;
        public TextMeshProUGUI if_statement;
        public TextMeshProUGUI if_content;
        public TextMeshProUGUI if_else;
        public TextMeshProUGUI if_else_content;
        public GameObject watchCodeExecution;
        private bool entered;
        private bool timeDone;
        public GameObject explainIfElse;
        public GameObject explainCanvas;
        public GameObject useArrows;
        public GameObject fixingBug;
        public GameObject pause;
        public GameObject glossary;
        public GameObject setting;
        public float steering;
        public float accel;
        private Rigidbody m_Rigidbody;
        private WheelCollider[] m_WheelColliders = new WheelCollider[4];
        public static float TURNING = 0;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            m_Rigidbody = GetComponent<Rigidbody>();
            //m_WheelColliders = GetComponent<WheelCollider[]>();
            if_statement.text = "if (left_arrow_key_pressed() {";
            if_else.text = "else if (right_arrow_key_pressed()) {";
            explainIfElse.SetActive(false);
            watchCodeExecution.SetActive(false);
            pause.SetActive(false);
            glossary.SetActive(false);
            setting.SetActive(false);
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //print("H" + (h * 10000).ToString());
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            //print("V" + v.ToString());
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            //m_Car.Move(5, 2, v, handbrake)
            if (drop1.transform.childCount > 0 && drop2.transform.childCount > 0)
            {
                //m_Car.ApplyDrive(2, 0);
                m_Car.Move(TURNING, 2, 0, 0);
                dragAndDropCanvas.SetActive(false);
                if (countdown.active == false)
                {
                    StartCoroutine(Example((float)3));
                    useArrows.SetActive(true);
                }
                //steering = Mathf.Clamp(1, -1, 1);
                //accel = Mathf.Clamp(100, 0, 1);
                //m_Car.ApplyDrive(100, 0);
                //m_WheelColliders[0].steerAngle = 10;
                //m_WheelColliders[1].steerAngle = 10;
                if (drop1.transform.GetChild(0).tag == "left")
                {
                    //m_Car.ApplyDrive(2,0);
                    ClickRight.turn = 5;
                    //m_Car.Move(5, 2, v, handbrake);
                    correct_input = true;
                }
                else if (drop1.transform.GetChild(0).tag == "right")
                {
                    //m_Car.Move(-5, 2, v, handbrake);
                    //m_Car.ApplyDrive(2, 0);
                    ClickRight.turn = -5;

                }
                else
                {
                    m_Car.Move(0, 0, 0, 0);
                }
                if_content.text = drop1.transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text + "}" ;
                if_else_content.text = drop2.transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text + "}";

            }
            if (fixingBug.active == true)
            {
                watchCodeExecution.SetActive(true);
                pause.SetActive(true);
                glossary.SetActive(true);
                setting.SetActive(true);
            }
            if (watchCodeExecution.active == true && ClickLeft.left_clicked)
            {
                // to make it dull use (150, 20, 45, 45), for it to be dark, use (255, 128, 0, 255)
                if_else.color = new Color32(150, 20, 45, 45);
                if_else_content.color = new Color32(150, 20, 45, 45);
                if_statement.color = new Color32(255, 128, 0, 255);
                if_content.color = new Color32(255, 128, 0, 255);
                entered = false;
            }
            else if (watchCodeExecution.active == true && ClickRight.right_clicked)
            {
                //Debug.Log("entered" + entered.ToString());
                if (!entered)
                {
                    Debug.Log("entered");
                    explainIfElse.SetActive(true);
                    if_statement.color = new Color32(255, 128, 0, 255);
                    StartCoroutine(Example((float)0.1));
                    entered = true;
                }
                if (timeDone)
                {
                    if_statement.color = new Color32(150, 20, 45, 45);
                    if_content.color = new Color32(150, 20, 45, 45);
                    if_else.color = new Color32(255, 128, 0, 255);
                    if_else_content.color = new Color32(255, 128, 0, 255);
                }
            }
            else
            {
                if_content.color = new Color32(150, 20, 45, 45);
                if_statement.color = new Color32(150, 20, 45, 45);
                if_else.color = new Color32(150, 20, 45, 45);
                if_else_content.color = new Color32(150, 20, 45, 45);
                entered = false;
            }
            IEnumerator Example(float time)
            {
                timeDone = false;
                yield return new WaitForSeconds((float)time);
                timeDone = true;
            }
#else
            m_Car.Move(h, v, v, 0f);

#endif
        }
    }
}
