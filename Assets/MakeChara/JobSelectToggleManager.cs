using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MakeCharaResult;
using MakeCharaResult;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;

namespace MakeChara
{
    public class JobSelectToggleManager : MonoBehaviour
    {
        public static IPlayerMaker PlayerMaker;
        public GameObject jobTogglePrefab;
        public ToggleGroup jobToggleGroup;

        void Start()
        {
            makeJobToggle();
            selectFirstJob();
            selectJob();
        }

        public void makeJobToggle()
        {
            foreach (JOBs job in Enum.GetValues(typeof (JOBs)))
            {
                GameObject jobToggle;
                Text toggleText;
                jobToggle = (GameObject)Instantiate(jobTogglePrefab,
                    this.transform.position,
                    Quaternion.identity);
                jobToggle.transform.parent = this.transform;
                jobToggle.name = job.ToString();
                toggleText = jobToggle.transform.Find("Text").gameObject.GetComponent<Text>();
                toggleText.text = job.GetStringValue();
                jobToggle.GetComponent<Toggle>().group = jobToggleGroup;
            }
        }

        void selectFirstJob()
        {
            Toggle firstToggle = transform.GetChild(0).gameObject.GetComponent<Toggle>();
            firstToggle.isOn = true;
        }

        public void selectJob()
        {
            Toggle activeToggle = jobToggleGroup.ActiveToggles().FirstOrDefault();
            Type type = Type.GetType("MakeCharaResult." + activeToggle.name);
            PlayerMaker = (IPlayerMaker) Activator.CreateInstance(type);
        }
    }
}
