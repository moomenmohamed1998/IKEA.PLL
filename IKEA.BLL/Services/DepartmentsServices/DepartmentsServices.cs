using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.DTO_s.Department;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistance.Repositories.Departments;

namespace IKEA.BLL.Services.DepartmentsServices
{
    public class DepartmentsServices : IDepartmentsServices
    {
        private IDepartmentRepository Repository;

        public DepartmentsServices(IDepartmentRepository _repositoryc)
        {
            //departmentRepository = new DepartmentRepository();
            Repository = _repositoryc;


        }

        public int CreateDepartment(CreateDepartmentDto departmentDto)
        {
            var createdDepartment = new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                createdBy = 1,
                CreatedOn = DateTime.Now,
                LastModifiedBy = 1,
                LastModifiedon = DateTime.Now,
            };
            return Repository.Add(createdDepartment);
        }
        public int UpdateDepartment(int id, UpdatedDepartmentDto departmentDto)
        {
            var UpdateDepartment = new Department()
            {
                Id = id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                LastModifiedBy = 1,
                createdBy = 1,
            };
            return Repository.update(UpdateDepartment);
        }

        public bool DeleteDepartment(int id)
        {
            var DeleteDepartment = Repository.GetById(id);
            //int result=0;
            if (DeleteDepartment is not null)

                //DeleteDepartment.IsDeleted = true;
               return  Repository.Delete(DeleteDepartment)>0;
                   else
                return false;
        }

        public DepartmentDetailsDto? GetALLDepartmentById(int id)
        {

            var Department = Repository.GetById(id);
            if (Department is not null)
                return new DepartmentDetailsDto()
                {
                    id = Department.Id,
                    Name = Department.Name,
                    Code = Department.Code,
                    Description = Department.Description,
                    CreationDate = Department.CreationDate,
                    createdBy = Department.createdBy,
                    CreatedOn = Department.CreatedOn,
                    LastModifiedBy = Department.LastModifiedBy,
                    IsDeleted = Department.IsDeleted,
                };
            return null;
        }

        public IEnumerable<DepartmentDto> GetALLDepartments()
        {
            var Departments = Repository.GetAll().Where(D=>!D.IsDeleted). Select(dept => new DepartmentDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                CreationDate = dept.CreationDate,
            }).ToList();
            return Departments;        
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            throw new NotImplementedException();
        }
    }
}
