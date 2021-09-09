using HM.BLL.Interfaces;
using HM.BLL.ViewModels.Comment;
using HM.BLL.ViewModels.Feedback;
using HM.BLL.ViewModels.MediaFiles;
using HM.BLL.ViewModels.Product;
using HM.DAL.Patterns;
using HM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        public FeedbackService(IUnitOfWork _db, IProductService _productService, IMediaFilesService _mediaFilesService)
        {
            db = _db;
            productService = _productService;
            mediaFilesService = _mediaFilesService;
        }
        private readonly IUnitOfWork db;
        private readonly IProductService productService;
        private readonly IMediaFilesService mediaFilesService;

        public async Task<Guid> CreateFeedbackAsync(CreateFeedback feedback)
        {
            try
            {
                var productId = await productService.CreateProductAsync(new CreateProduct() { Name = feedback.ProductName, Category = feedback.ProductCategory });

                var dbFeedback = new Feedback()
                {
                    AuthorName = feedback.AuthorName,
                    CreationDate = DateTime.Now,
                    ProductId = productId,
                    Rate = feedback.Rate,
                    Text = feedback.Text
                };
                dbFeedback = await db.Feedbacks.CreateAsync(dbFeedback);

                if(feedback.MediaFiles!=null && feedback.MediaFiles.Any())
                {
                    feedback.MediaFiles.Select(m =>
                    {
                        m.FeedbackId = dbFeedback.Id;
                        return mediaFilesService.CreateMediaFilesAsync(m);
                    });
                }
                return dbFeedback.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoFeedback> FindFeedbacksByFunc(Func<Feedback, bool> func)
        {
            try
            {
                List<Feedback> dbFeedbacks;
                if(func == null)
                {
                    dbFeedbacks = db.Feedbacks.GetAll().ToList();
                }
                else
                {
                    dbFeedbacks = db.Feedbacks.GetAll().Where(func).ToList();
                }
                return dbFeedbacks.Select(m =>
                {
                    return new InfoFeedback()
                    {
                        CreationDate = m.CreationDate,
                        AuthorName = m.AuthorName,
                        ProductName = m.Product.Name,
                        Rate = m.Rate,
                        Text = m.Text,
                        Comments = m.Comments.Select(n =>
                        {
                            return new InfoComment()
                            {
                                CreationDate = n.CreationDate,
                                AuthorName = n.AuthorName,
                                ProductName = n.Feedback.Product.Name,
                                Text = n.Text,
                                FeedbackId = n.FeedbackId
                            };
                        }).ToList(),
                        MediaFiles = m.MediaFiles.Select(e =>
                        {
                            return new CreateMediaFiles()
                            {
                                FeedbackId = e.FeedbackId,
                                Name = e.Name,
                                Path = e.Path,
                                Type = e.Type
                            };
                        }).ToList()
                    };
                }).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
