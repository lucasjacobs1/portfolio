﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface ISportService
    {
        List<Sport> GetAllSports();
        Sport GetSportById(int id);
    }
}
