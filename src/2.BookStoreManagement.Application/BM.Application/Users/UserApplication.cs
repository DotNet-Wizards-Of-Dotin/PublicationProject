using BM.Application.Contracts.Books;
using BM.Application.Contracts.Users;
using BM.Domain.UoW;
using BM.Domain.Users;
using FW.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Application.Users
{
    public class UserApplication : IBookApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork ;
        private readonly IFileUploader _fileUploader;
        private readonly ;

        public UserApplication(IUserRepository userRepository, IUnitOfWork unitOfWork, IFileUploader fileUploader)
        {
            _userRepository=userRepository;
            _unitOfWork=unitOfWork;
            _fileUploader=fileUploader;
        }

        public OperationResult Create(CreateUser command)
        {
            _unitOfWork.BeginTransaction();
            var operationResult = new OperationResult();
            if (_userRepository.Exists(u => u.Fullname == command.Fullname))
            {
                _unitOfWork.RollBack();
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            }
            var 
        }

        public OperationResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditBook command)
        {
            throw new NotImplementedException();
        }

        public List<BookViewModel> GetBooks()
        {
            throw new NotImplementedException();
        }

        public EditBook GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookViewModel> Search(BookSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
