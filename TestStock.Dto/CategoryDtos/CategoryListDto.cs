﻿using TestStock.Core.Entity;

namespace TestStock.Dto.CategoryDtos
{
    public class CategoryListDto : IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
