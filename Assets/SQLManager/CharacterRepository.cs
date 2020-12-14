using System;
using System.Collections;
using System.Collections.Generic;
using AllChara;
using UnityEngine;

namespace SQLManager
{
    public class CharacterRepository : IRepository
    {
        public const int MAX_CHARA_NUMBER = 20;

        public SqliteDatabase sqlDB;

        public DataTable dataTable;

        public CharacterRepository()
        {
            sqlDB = new SqliteDatabase("SQLLite.db");
        }

        public DataTable getAllData(TableNames table)
        {
            string selectQuery = $"select * from {table}";
            dataTable = sqlDB.ExecuteQuery(selectQuery);
            return dataTable;
        }

        public int countTableRows(TableNames table)
        {
            dataTable = this.getAllData(table);
            int RowNumber = dataTable.Rows.Count;
            return RowNumber;
        }

        public List<PlayerDTO> getPlayerDTOList(TableNames table)
        {
            List<PlayerDTO> playerDTOList = new List<PlayerDTO>();
            DataTable dataTable = this.getAllData(table);
            foreach (DataRow dr in dataTable.Rows)
            {
                PlayerDTO playerDTO = new PlayerDTO();
                playerDTO.PlayerName = (string) dr["NAME"];
                int jobInt = (int) dr["JOB"];
                playerDTO.JOB = (JOBs) Enum.ToObject(typeof (JOBs), jobInt);
                playerDTO.HP = (int) dr["HP"];
                playerDTO.MP = (int) dr["MP"];
                playerDTO.STR = (int) dr["STR"];
                playerDTO.DEF = (int) dr["DEF"];
                playerDTO.AGI = (int) dr["AGI"];
                playerDTO.LUCK = (int) dr["LUCK"];
                if (dr["CREATE_AT"] != null)
                {
                    playerDTO.CreateDay =
                        DateTime.Parse((string) dr["CREATE_AT"]);
                }
                playerDTOList.Add (playerDTO);
            }
            return playerDTOList;
        }

        public void addData(PlayerDTO playerDTO, TableNames table)
        {
            string query =
                $"insert into {table.ToString()} values(\'{playerDTO.PlayerName}\',{(int)playerDTO.JOB},{playerDTO.HP},{playerDTO.MP},{playerDTO.STR}," +
                $"{playerDTO.DEF},{playerDTO.AGI},{playerDTO.LUCK},\'{playerDTO.CreateDay}\')";
            sqlDB.ExecuteNonQuery (query);
        }

        public PlayerDTO getPlayerDTO(string playerName, TableNames table)
        {
            return this
                .getPlayerDTOList(table)
                .Find(n => n.PlayerName == playerName);
        }

        public PlayerDTO getPlayerDTO(int playerId, TableNames table)
        {
            return this.getPlayerDTOList(table)[playerId];
        }

        public void deletePlayer(int playerId, TableNames table)
        {
            string query =
                $"delete from {table.ToString()} where NAME = (select NAME from " +
                $"{table.ToString()} limit 1 offset {playerId.ToString()})";
            sqlDB.ExecuteNonQuery (query);
        }

        public bool canNotAddName(string name)
        {
            foreach (var player in getPlayerDTOList(TableNames.CHARACTER))
            {
                if (player.PlayerName == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool charaNumberIsFull()
        {
            if (this.countTableRows(TableNames.CHARACTER) >= MAX_CHARA_NUMBER)
            {
                return true;
            }
            return false;
        }

        public List<PlayerDTO> getmyTeamAllCharaList()
        {
            return this.getPlayerDTOList(TableNames.CHARACTER);
        }

        public List<PlayerDTO> getEnemyTeamAllCharaList()
        {
            return this.getPlayerDTOList(TableNames.ENEMY);
        }

        public PlayerDTO getEnemyPlayerDTO(int playerId)
        {
            return this.getPlayerDTO(playerId, TableNames.ENEMY);
        }

        public PlayerDTO getmyTeamPlayerDTO(int playerId)
        {
            return this.getPlayerDTO(playerId, TableNames.CHARACTER);
        }

        public int countEnemyTableRows()
        {
            return this.countTableRows(TableNames.ENEMY);
        }

        public int countmyTeamTableRows()
        {
            return this.countTableRows(TableNames.CHARACTER);
        }

        public void deletemyTeamPlayer(int playerId)
        {
            this.deletePlayer(playerId, TableNames.CHARACTER);
        }

        public void addmyTeamChara(PlayerDTO playerDTO)
        {
            this.addData(playerDTO, TableNames.CHARACTER);
        }

        public int getMaxCharaNumber(){
            return MAX_CHARA_NUMBER;
        }
    }
}
