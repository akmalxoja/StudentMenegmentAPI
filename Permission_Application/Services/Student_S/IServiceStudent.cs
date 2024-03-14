using VehicleManagement_Application.Dto_s;
using VehicleManagement_Domen.Entityes;

namespace Permission_Application.Services.Teacher_S
{
    public interface IServiceStudent
    {
        public Task<IEnumerable<Students>> GetAllAsync();
        public Task<Students> GetById(int Id);
        public Task<Students> CreateAsync(StudentDto transportDto, string formFile);
        public Task<Students> UpdateAsync(int id, StudentDto transportDto ,string fromFile);
        public Task<bool> DeleteAsync(int id);
    }
}
