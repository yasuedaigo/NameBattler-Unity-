using System.Collections;
using System.Collections.Generic;
using BattleScene.Chara;
using BattleScene.Tactics;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene
{
    public class TextManager : MonoBehaviour
    {
        public Text targettext;

        public ScrollRect scrollrect;

        void Start()
        {
            targettext = GameObject.Find("battletext").GetComponent<Text>();
            scrollrect =
                GameObject.Find("ScrollText").GetComponent<ScrollRect>();
        }

        public void battleLog(object message)
        {
            targettext.text = targettext.text.ToString() + "\r\n" + message;
            targettext.GetComponent<ContentSizeFitter>().SetLayoutVertical();
            scrollrect.verticalNormalizedPosition = 0;
        }
    }
}
