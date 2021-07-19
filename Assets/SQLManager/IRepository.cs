using System.Collections;
using System.Collections.Generic;
using AllChara;
using SQLManager;
using UnityEngine;

namespace SQLManager
{
    public interface IRepository
    {
        DataTable getAllData(TableNames table);

        int countTableRows(TableNames table);

        List<PlayerDTO> getPlayerDTOList(TableNames table);

        void addData(PlayerDTO playerDTO, TableNames table);

        PlayerDTO getPlayerDTO(string playerName, TableNames table);

        PlayerDTO getPlayerDTO(int playerId, TableNames table);

        void deletePlayer(int rowId, TableNames table);

        bool canNotAddName(string name);

        bool charaNumberIsFull();

        List<PlayerDTO> getmyTeamAllCharaList();

        List<PlayerDTO> getEnemyTeamAllCharaList();

        PlayerDTO getEnemyPlayerDTO(int playerId);

        PlayerDTO getmyTeamPlayerDTO(int playerId);

        int countmyTeamTableRows();

        int countEnemyTableRows();

        void deletemyTeamPlayer(int playerId);

        void addmyTeamChara(PlayerDTO playerDTO);

        int getMaxCharaNumber();
    }
}
