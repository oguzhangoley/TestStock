﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Entity;

namespace TestStock.Dto.CategoryDtos
{
    public class CategoryCreateDto : IDto
    {
        public string CategoryName { get; set; }
    }
}
