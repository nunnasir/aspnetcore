using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyExpense.Framework
{
    public class CategoryService : ICategoryService, IDisposable
    {
        private IExpenseUnitOfWork _expenseUnitOfWork;
        public CategoryService(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }
        public void CreateCategory(Category category)
        {
            var count = _expenseUnitOfWork.CategoryRepository.GetCount(c => c.Name == category.Name);
            if (count > 0)
                throw new DuplicateException("Category title already exists!", category.Name);

            _expenseUnitOfWork.CategoryRepository.Add(category);
            _expenseUnitOfWork.Save();
        }

        public void EditCategory(Category category)
        {
            var count = _expenseUnitOfWork.CategoryRepository.GetCount(c => c.Name == category.Name && c.Id != category.Id);
            if (count > 0)
                throw new DuplicateException("Category title already exists!", category.Name);

            _expenseUnitOfWork.CategoryRepository.Edit(category);
            _expenseUnitOfWork.Save();
        }

        public Category DeleteCategory(int id)
        {
            var category = _expenseUnitOfWork.CategoryRepository.GetById(id);
            _expenseUnitOfWork.CategoryRepository.Remove(category);
            _expenseUnitOfWork.Save();
            return category;
        }

        public Category GetCategory(int id)
        {
            return _expenseUnitOfWork.CategoryRepository.GetById(id);
        }

        public void Dispose()
        {
            _expenseUnitOfWork?.Dispose();
        }

        public (IList<Category> records, int total, int totalDisplay) GetCategories(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != "")
                return _expenseUnitOfWork.CategoryRepository.GetDynamic(c => c.Name.Contains(searchText), sortText, "", pageIndex, pageSize, false);
            else
                return _expenseUnitOfWork.CategoryRepository.GetDynamic(null, sortText, "", pageIndex, pageSize, false);
            
        }
        
    }
}
