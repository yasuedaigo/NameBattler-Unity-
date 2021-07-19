using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using SQLManager;
using MakeChara;
using MakeCharaResult;

namespace MakeCharaTests
{
    public class Tests_MakeChara
    {
        InputFieldManager inputfieldmanager;
        JobSelectToggleManager jobselecttogglemanager;
        JobTogggleScript jobtogglescript;
        InputField inputfield;
        Text messagetext;
        Button addbutton;

        [UnityTest]
        public IEnumerator tests_inputField()
        {
            preparation();
            inputfield.text = "12345123451234512345";
            inputfieldmanager.nameValidation();
            Assert.That(messagetext.text == "");
            Assert.That(InputFieldManager.charaName  == "12345123451234512345");
            Assert.IsTrue(addbutton.interactable == true);
            inputfield.text = "123451234512345123451";
            inputfieldmanager.nameValidation();
            Assert.That(messagetext.text == "プレイヤー名は20字以内にしてください");
            Assert.That(InputFieldManager.charaName  == "123451234512345123451");
            Assert.IsTrue(addbutton.interactable == false);
            yield return null;
        }

        [UnityTest]
        public IEnumerator tests_checkBox()
        {
            preparation();
            Toggle fightertoggle = GameObject.Find("Fighter").GetComponent<Toggle>();
            fightertoggle.isOn = true;
            jobselecttogglemanager.selectJob();
            Assert.That(JobSelectToggleManager.PlayerMaker.GetType() == typeof(MakeCharaResult.Fighter));
            Toggle wizardtoggle = GameObject.Find("Wizard").GetComponent<Toggle>();
            wizardtoggle.isOn = true;
            jobselecttogglemanager.selectJob();
            Assert.That(JobSelectToggleManager.PlayerMaker.GetType() == typeof(MakeCharaResult.Wizard));
            Toggle priesttoggle = GameObject.Find("Priest").GetComponent<Toggle>();
            priesttoggle.isOn = true;
            jobselecttogglemanager.selectJob();
            Assert.That(JobSelectToggleManager.PlayerMaker.GetType() == typeof(MakeCharaResult.Priest));
            Toggle ninjatoggle = GameObject.Find("Ninja").GetComponent<Toggle>();
            ninjatoggle.isOn = true;
            jobselecttogglemanager.selectJob();
            Assert.That(JobSelectToggleManager.PlayerMaker.GetType() == typeof(MakeCharaResult.Ninja));
            yield return null;
        }

        public void preparation()
        {
            inputfieldmanager = GameObject.Find("InputField").GetComponent<InputFieldManager>();
            inputfieldmanager.Start();
            inputfield = GameObject.Find("InputField").GetComponent<InputField>();
            messagetext = GameObject.Find("messageText").GetComponent<Text>();
            addbutton = GameObject.Find("addButton").GetComponent<Button>();
            jobselecttogglemanager = GameObject.Find("Content").GetComponent<JobSelectToggleManager>();
            jobselecttogglemanager.Start();
            jobtogglescript = GameObject.Find("Fighter").GetComponent<JobTogggleScript>();
        }
    }
}