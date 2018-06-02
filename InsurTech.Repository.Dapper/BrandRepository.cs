using Dapper;
using InsurTech.Data.Model;
using InsurTech.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurTech.Repository.Dapper
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbConnection _dbConnection;
        public BrandRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public async Task AddBrand(Brand brand)
        {
            var sql = "INSERT INTO DBO.BRAND (BrandName) VALUES(@BrandName)";
            _dbConnection.Open();
            using (var tran = _dbConnection.BeginTransaction())
            {
                await _dbConnection.ExecuteAsync(sql, brand, tran, null, CommandType.Text);
                tran.Commit();
            }
            _dbConnection.Close();
        }

        public async Task<List<Brand>> GetBrands()
        {
            var sql = "SELECT * FROM DBO.Brand";
            _dbConnection.Open();
            var brands = await _dbConnection.QueryAsync<Brand>(sql);
            _dbConnection.Close();
            return brands.ToList();
        }
    }
}
