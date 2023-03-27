namespace sharpList.Repositories
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  using sharpList.Models;

  public class HousesRepository
    {
        
        private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int deleteHouse(int id)
    {
        string sql = @"
        DELETE FROM houses WHERE id = @id;
        ";

        int rows = _db.Execute(sql, new {id});
        return rows;
    }

    internal int editHouse(House house)
    {
        string sql = @"
        UPDATE houses
        set
        bedrooms = @bedrooms,
        bathrooms = @bathrooms,
        floors = @floors
        WHERE id = @id
        ";
        int rows = _db.Execute(sql, house);
        return rows;

    }

    internal List<House> getAllHouses()
    {
        string sql = @"
        SELECT
        *
        FROM houses;
        ";

        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;
    }

    internal House getHouseById(int houseId)
    {
        string sql = @"
        SELECT
        *
        FROM houses
        WHERE id = @id;
        ";

        int id = houseId;

        House house = _db.Query<House>(sql, new {id}).FirstOrDefault();
        return house;
    }

    internal House postHouse(House houseData)
    {
        string sql = @"
        INSERT INTO houses
        (bedrooms, bathrooms, floors, address)
        VALUES
        (@bedrooms, @bathrooms, @floors, @address);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, houseData);
        houseData.id = id;
        return houseData;
    }
    }
}