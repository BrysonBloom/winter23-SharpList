namespace sharpList.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Car> FindAll()
  {
    string sql = @"
   SELECT
   *
   FROM cars;
   ";
    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }

  internal Car FindOne(int id)
  {
    string sql = @"
    SELECT 
    *
    FROM cars
    WHERE id = @id;
    ";
    Car car = _db.Query<Car>(sql, new { id }).FirstOrDefault();
    return car;
  }

  internal Car Create(Car carData)
  {
    string sql = @"
    INSERT INTO cars
    (make, model, year, price, imgUrl, description, color)
    VALUES
    (@make, @model, @year, @price, @imgUrl, @description, @color);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, carData);
    carData.Id = id;
    return carData;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM cars WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows == 1;
  }

  internal int Update(Car update)
  {
    string sql = @"
    UPDATE cars
    SET
    make = @make,
    model = @model,
    year = @year,
    price = @price,
    color = @color,
    imgUrl = @imgUrl,
    description = @description
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, update);
    return rows;
  }
}
