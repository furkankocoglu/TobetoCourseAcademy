using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entites.Concretes;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal insturctorDal)
        {
            _instructorDal = insturctorDal;
        }
        [ValidationAspect(typeof(InstructorValidator))]
        public IResult Add(Instructor instructor)
        {
            _instructorDal.Add(instructor);
            return new SuccessResult(Messages.InstructorAdded);
        }

        public IResult Delete(Instructor instructor)
        {
            _instructorDal.Delete(instructor);
            return new SuccessResult(Messages.InstructorDeleted);
        }

        public IDataResult<Instructor> Get(Expression<Func<Instructor, bool>> filter)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.Get(filter),Messages.InstructorListed);
        }

        public IDataResult<List<Instructor>> GetAll(Expression<Func<Instructor, bool>> filter = null)
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll(filter), Messages.InstructorListed);
        }

        public IDataResult<Instructor> GetById(int id)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.Get(i=>i.Id==id),Messages.InstructorListed);

        }

        public IResult Update(Instructor instructor)
        {
            _instructorDal.Update(instructor);
            return new SuccessResult(Messages.InstructorUpdated);
        }
    }
}
