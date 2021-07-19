using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace SQLManager
{
    public class PlayerDTO
    {
        public string PlayerName { get; set; }

        public JOBs JOB { get; set; }

        public int JOBInt { get; set; }

        public int HP { get; set; }

        public int STR { get; set; }

        public int DEF { get; set; }

        public int LUCK { get; set; }

        public int AGI { get; set; }

        public int MP { get; set; }

        public string CreateDay { get; set; }
    }
}
