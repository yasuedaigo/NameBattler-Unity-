using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MakeChara
{
    public class InputFieldManager : MonoBehaviour
    {
        public static string charaName; 
        public Button addButton;
        public Text messageText;
        const int LIMITOFNAME = 20;
        InputField inputField;

        void Start()
        {
            inputField =
                GameObject.Find("InputField").GetComponent<InputField>();
        }

        public void nameValidation()
        {
            addButton.interactable = false;
            charaName = inputField.text;
            if(NameIsEmpty() || NameIsOutOfLenght()){
                addButton.interactable = false;
            }else{
                addButton.interactable = true;
            }
        }

        bool NameIsEmpty(){
            if(charaName == null || charaName == ""){
                return true;
            }
            return false;
        }

        bool NameIsOutOfLenght(){
            if(charaName.Length > LIMITOFNAME){
                messageText.text = $"プレイヤー名は{LIMITOFNAME}字以内にしてください";
                return true;
            }
            return false;
        }

        public static string GetName()
        {
            return charaName;
        }
    }
}
