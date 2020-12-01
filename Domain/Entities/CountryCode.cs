﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    //https://geo.koltyrin.ru/kody_stran_mira.php
    public class CountryCode : BaseEntity
    {
        public string Code { get; set; }
        public string ISOName { get; set; }
    }
}
