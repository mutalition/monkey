﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monkey.Games.Catan
{
    public interface IGameUpdate
    {
        GameState? State
        {
            get;
        }

    }
}