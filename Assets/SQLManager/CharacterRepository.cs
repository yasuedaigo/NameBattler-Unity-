using System;
using System.Collections;
using System.Collections.Generic;
using AllChara;
using UnityEngine;

namespace SQLManager
{
    public class CharacterRepository : IRepository
    {
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

        public int getRowint(TableNames table)
        {
            dataTable = this.getAllData(table);
            int Rowint = dataTable.Rows.Count;
            return Rowint;
        }

        public List<PlayerDTO> getPlayerDTOList(TableNames table)
        {
            List<PlayerDTO> playerDTOList = new List<PlayerDTO>();
            DataTable dataTable = this.getAllData(table);
            foreach (DataRow dr in dataTable.Rows)
            {
                PlayerDTO playerDTO = new PlayerDTO();
                playerDTO.PlayerName = (string) dr["NAME"];
                int jobint = (int) dr["JOB"];
                playerDTO.JOB = (JOBs) Enum.ToObject(typeof (JOBs), jobint);
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

        public PlayerDTO getPlayerDTO(string playername, TableNames table)
        {
            return this
                .getPlayerDTOList(table)
                .Find(n => n.PlayerName == playername);
        }

        public PlayerDTO getPlayerDTO(int playerint, TableNames table)
        {
            return this.getPlayerDTOList(table)[playerint];
        }

        public void deletePlayer(int rowid, TableNames table)
        {
            string query =
                $"delete from {table.ToString()} where NAME = (select NAME from " +
                $"{table.ToString()} limit 1 offset {rowid.ToString()})";
            sqlDB.ExecuteNonQuery (query);
        }

        public bool canAddCharaName(string name)
        {
            bool nameOK = true;
            foreach (var player in getPlayerDTOList(TableNames.CHARACTER))
            {
                if (player.PlayerName == name)
                {
                    nameOK = false;
                }
            }
            return nameOK;
        }

        public bool canAddCharaNumber()
        {
            bool numberOK = true;
            if (this.getRowint(TableNames.CHARACTER) >= 20)
            {
                numberOK = false;
            }
            return numberOK;
        }

        public List<PlayerDTO> getmyTeamAllCharaList()
        {
            return this.getPlayerDTOList(TableNames.CHARACTER);
        }

        public List<PlayerDTO> getEnemyTeamAllCharaList()
        {
            return this.getPlayerDTOList(TableNames.ENEMY);
        }

        public PlayerDTO getENEMYPlayerDTO(int playerint)
        {
            return this.getPlayerDTO(playerint, TableNames.ENEMY);
        }

        public PlayerDTO getmyTeamPlayerDTO(int playerint)
        {
            return this.getPlayerDTO(playerint, TableNames.CHARACTER);
        }

        public int getEnemyRowint()
        {
            return this.getRowint(TableNames.ENEMY);
        }

        public int getmyTeamRowint()
        {
            return this.getRowint(TableNames.CHARACTER);
        }

        public void deletemyTeamPlayer(int playerint)
        {
            this.deletePlayer(playerint, TableNames.CHARACTER);
        }

        public void addmyTeamData(PlayerDTO playerDTO)
        {
            this.addData(playerDTO, TableNames.CHARACTER);
        }
    }
}
