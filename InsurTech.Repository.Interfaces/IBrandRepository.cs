namespace InsurTech.Repository.Interfaces
{
    using InsurTech.Data.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBrandRepository
    {
        Task<List<Brand>> GetBrands();

        Task AddBrand(Brand brand);

    }
}
