using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EFCategoryRepository eFCategoryRepository;
        public CategoryManager()
        {
            eFCategoryRepository = new EFCategoryRepository();
        }
        public void CategoryAdd(Category category)
        {
            eFCategoryRepository.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            eFCategoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            eFCategoryRepository.Update(category);
        }

        public Category GetById(int id)
        {
            return eFCategoryRepository.GetById(id);
        }

        public List<Category> GetList()
        {
            return eFCategoryRepository.GetListAll();
        }
    }
}
