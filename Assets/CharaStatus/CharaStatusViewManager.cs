using System;
using System.Collections;
using System.Collections.Generic;
using AllChara;
using SQLManager;
using UnityEngine;
using UnityEngine.UI;
using ViewManager;

namespace CharaStatus
{
    public class CharaStatusViewManager : MonoBehaviour
    {
        CharaStatusController charaStatusController;
        PlayerDTO selectedCharaDTO;

        void Start()
        {
            charaStatusController =
                GameObject.Find("CharaStatusText").GetComponent<CharaStatusController>();
            selectedCharaDTO =
                charaStatusController.getmyTeamPlayerDTO(AllChara.AllCharaViewManager.selectedCharaNum);
            Text playerText = this.GetComponent<Text>();
            PlayerTextManager.drowNameAndStatus(playerText,selectedCharaDTO);
        }
    }
}
