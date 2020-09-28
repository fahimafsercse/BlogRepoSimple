using Interface.IRepo;
using Interface.IUnityOfWork;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repository.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly BS23DBContext context;

        public UnityOfWork(BS23DBContext context)
        {
            this.context = context;
        }

        private IGenericRepo<CommentDetail> CommentgenericRepo;
        private IGenericRepo<PostDetail> PostGenericRepo;
        #region RepositoryClasses
        private IGenericRepo<UserInformation> UserInformationGenericRepository;
        #endregion
        private IUserRepo UserRepository;
        public IUserRepo userRepository
        {
            get
            {
                if (this.UserRepository == null)
                    this.UserRepository = new UserRepoAsync(context);
                return UserRepository;
            }
        }
        private IAdminUserRepo AdminUserRepo;
        public IAdminUserRepo adminUserRepository
        {
            get
            {
                if (this.AdminUserRepo == null)
                    this.AdminUserRepo = new AdminUserRepo(context);
                return AdminUserRepo;
            }
        }
        public IGenericRepo<UserInformation> userInformationGenericRepo
        {
            get
            {
                if (this.UserInformationGenericRepository == null)
                    this.UserInformationGenericRepository = new GenericRepo<UserInformation>(context);
                return UserInformationGenericRepository;
            }
        }
        public IGenericRepo<CommentDetail> genricCommentDetailRepo
        {
            get
            {
                if (this.CommentgenericRepo == null)
                {
                    this.CommentgenericRepo = new GenericRepo<CommentDetail>(context);
                }
                return CommentgenericRepo;
            }
        }
        public IGenericRepo<PostDetail> genricPostDetailRepo
        {
            get
            {
                if (this.PostGenericRepo == null)
                {
                    this.PostGenericRepo = new GenericRepo<PostDetail>(context);
                }
                return PostGenericRepo;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}