using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cigarette.Enterprise.DAL; 
using Cigarette.Enterprise.DAL.Repository;
using PagedList;

namespace Cigarette.Enterprise.BLL.NewsServ
{
    public class NewsService : INewsService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public long Add(News news)
        {
            var added = _unitOfWork.News.Add(news);
            return added.Id;
        }

        public long Edit(News news)
        {
            return _unitOfWork.News.Update(news);
        }

        public long GetAllCount()
        {
            return _unitOfWork.News.GetAll().Count();
        }

        public IEnumerable<News> GetAll()
        {
            return _unitOfWork.News.GetAll().OrderByDescending(m => m.Id).ToList();
        }

        public bool Delete(long id)
        {
            var result = _unitOfWork.News.Get(id);
            if (result == null)
            {
                return false;
            }

            var deleted = _unitOfWork.News.Remove(result);
            return deleted > 0;
        }

        public News Get(long id)
        {
            return _unitOfWork.News.Get(id);
        }

        public bool DeleteRange(List<long> news)
        {
            var newsList = new List<News>();
            foreach (var item in news)
            {
                var model = _unitOfWork.News.Get(item);
                if (model == null)
                {
                    return false;
                }
                newsList.Add(model);
            }
            var result = _unitOfWork.News.RemoveRange(newsList);

            return result > 0;
        }

        public Result<IPagedList<News>> GetAllPaged(int pageSize, int pageNo)
        {
            var data = _unitOfWork.News.GetAll()
                .Where(m => m.Active == true)
                .OrderByDescending(m => m.Id)
                .ToPagedList(pageNo, pageSize);
            var result = new Result<IPagedList<News>>
            {
                Data = data,
                Succeeded = true
            };

            return result;
        }
        public void IncreaseCount(long id)
        {
            _unitOfWork.SaudiceosEntities.IncreaseViews((int)id, 1, 1);
        }

        public Result<IPagedList<News>> GetRelatedPaged(long id, int pageSize, int pageNo)
        {
            var model = _unitOfWork.News.Get(id);

            if (model != null)
            {
                var data = _unitOfWork.News.GetAll()
                   .Where(m => m.Active == true && (
                   m.CeoId == model.CeoId || m.Tags == model.Tags || m.Title.Contains(model.Title)
                   ))
                   .OrderBy(m => m.Id)
                   .ToPagedList(pageNo, pageSize);
                var result = new Result<IPagedList<News>>
                {
                    Data = data,
                    Succeeded = true
                };

                return result;
            }
            return  new Result<IPagedList<News>>
            { 
                Succeeded = false
            }; 
        }

        public IEnumerable<News> GetRelated(long id)
        {
            throw new NotImplementedException();
        }
    }
}
