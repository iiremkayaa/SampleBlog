using Project.Blog.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blog.Dto.DTOs.CategoryDtos
{
    public class CategoryListDtos :IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
