using Mapster;
using Microsoft.AspNetCore.Http;
using Permission_Application.Abstractions.Repositories;
using VehicleManagement_Application.Dto_s;
using VehicleManagement_Domen.Entityes;

namespace Permission_Application.Services.Teacher_S
{
    public class ServiceStudent : IServiceStudent
    {
        private readonly IStudnetRepositories _transportRepositories;
        public ServiceStudent(IStudnetRepositories transportRepositories) => _transportRepositories = transportRepositories;

        public async Task<Students> CreateAsync(StudentDto transportDto, string fieldInfo)
        {
            var newtrans = transportDto.Adapt<Students>();
            newtrans.ImageUrl = fieldInfo;
            newtrans.CreatedAt = DateTime.UtcNow;
            return await _transportRepositories.CreateAsync(newtrans);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var find = await _transportRepositories.GetAsync(id);
            return find != null;
        }

        public async Task<IEnumerable<Students>> GetAllAsync()
        {
            return await _transportRepositories.GetAllAsync();
        }

        public async Task<Students> GetById(int Id)
        {
                var result = await _transportRepositories.GetAsync(Id);
            return result != null ? result : null;
        }

        public async Task<Students> UpdateAsync(int id, StudentDto studentDto, string fileinfo)
        {
            var newtrans = await _transportRepositories.GetAsync(id);

            if( newtrans != null)
            {
                newtrans.Name = studentDto.Name;
                newtrans.Lastname = studentDto.Lastname;

                return await _transportRepositories.UpdateAsync(newtrans);
            }
            return null;
        }
    }
}