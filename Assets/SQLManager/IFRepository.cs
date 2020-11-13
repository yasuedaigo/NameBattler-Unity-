using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLManager;
using AllChara;

namespace SQLManager{

public interface IFRepository
{
    DataTable getAllData(TableNames table);

    int getRowint(TableNames table);

    List<PlayerDTO> getPlayerDTOList(TableNames table);

    void addData(PlayerDTO playerDTO,TableNames table);

    PlayerDTO getPlayerDTO(string playername,TableNames table);

    PlayerDTO getPlayerDTO(int playerint,TableNames table);

    void deletePlayer(int rowid,TableNames table);

    bool canAddCharaName(string name);

    bool canAddCharaNumber();

    List<PlayerDTO> getmyTeamAllCharaList();

    List<PlayerDTO> getEnemyTeamAllCharaList();

    PlayerDTO getENEMYPlayerDTO(int playerint);

    PlayerDTO getmyTeamPlayerDTO(int playerint);

    int getEnemyRowint();

    int getmyTeamRowint();

    void deletemyTeamPlayer(int playerint);

    void addmyTeamData(PlayerDTO playerDTO);
}

}
