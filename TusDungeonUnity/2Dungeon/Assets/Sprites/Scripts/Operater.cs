using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Actor
{
    class Operater
    {
        public key getKey()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                return key.up;
            }

            return key.none;
        }
    }



    enum key {none,up,down,right,left};
}