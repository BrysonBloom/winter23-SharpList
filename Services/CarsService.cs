namespace sharpList.Services;

public class CarsService
{
  private readonly CarsRepository _repo;

  public CarsService(CarsRepository repo)
  {
    _repo = repo;
  }

  internal List<Car> Find()
  {
    List<Car> cars = _repo.FindAll();
    return cars;
  }

  internal Car Find(int id)
  {
    Car car = _repo.FindOne(id);
    if (car == null) throw new Exception($"no car at id: {id}");
    return car;
  }

  internal Car Create(Car carData)
  {
    Car car = _repo.Create(carData);
    return car;
  }

  internal string Remove(int id)
  {
    Car car = this.Find(id);
    bool result = _repo.Remove(id);
    if (!result) throw new Exception($"something horrible when wrong when trying to delete {car.Make} {car.Model} @ id {car.Id}");
    return $"delorted {car.Make} {car.Model}";
  }

  internal Car Update(Car updateData)
  {
    Car original = this.Find(updateData.Id);
    original.Make = updateData.Make != null ? updateData.Make : original.Make;
    original.Model = updateData.Model != null ? updateData.Model : original.Model;
    original.Year = updateData.Year != 0 ? updateData.Year : original.Year;
    original.Price = updateData.Price != null ? updateData.Price : original.Price;
    original.ImgUrl = updateData.ImgUrl != null ? updateData.ImgUrl : original.ImgUrl;
    original.Color = updateData.Color != null ? updateData.Color : original.Color;
    original.Description = updateData.Description != null ? updateData.Description : original.Description;
    int rowsAffected = _repo.Update(original);
    if (rowsAffected == 0) throw new Exception($"could not modify {updateData.Make} {updateData.Model} @ id {updateData.Id} for some reason.");
    if (rowsAffected > 1) throw new Exception($"Something horrible just happend, you made at least {rowsAffected} of cars into {updateData.Make} {updateData.Model}, might wanna check the db");
    return original;
  }
}
