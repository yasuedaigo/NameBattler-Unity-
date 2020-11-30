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
    public class ToggleManager : MonoBehaviour
    {
        public static IPlayerMaker PlayerMaker;

        public GameObject jobtoggle;

        public ToggleGroup togglegroup;

        void Start()
        {
            makeJobToggle();
            Toggle firsttoggle =
                transform.GetChild(0).gameObject.GetComponent<Toggle>();
            firsttoggle.isOn = true;
            setActiveToggle();
        }

        public void setActiveToggle()
        {
            Toggle activeToggle = togglegroup.ActiveToggles().FirstOrDefault();
            Type type = Type.GetType("MakeCharaResult." + activeToggle.name);
            PlayerMaker = (IPlayerMaker) Activator.CreateInstance(type);
        }

        public void makeJobToggle()
        {
            foreach (JOBs job in Enum.GetValues(typeof (JOBs)))
            {
                GameObject Obj;
                Text jobtext;
                Obj =
                    (GameObject)
                    Instantiate(jobtoggle,
                    this.transform.position,
                    Quaternion.identity);
                Obj.transform.parent = this.transform;
                Obj.name = job.ToString();
                jobtext =
                    Obj.transform.Find("Text").gameObject.GetComponent<Text>();
                jobtext.text = job.GetStringValue();
                Obj.GetComponent<Toggle>().group = togglegroup;
            }
        }
    }
}
