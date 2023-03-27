namespace sharpList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService carsService;

  public CarsController(CarsService carsService)
  {
    this.carsService = carsService;
  }
  [HttpGet]
  public ActionResult<List<Car>> Find()
  {
    try
    {
      List<Car> cars = carsService.Find();
      return Ok(cars);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Car> Find(int id)
  {
    try
    {
      Car car = carsService.Find(id);
      return Ok(car);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Car> Create([FromBody] Car carData)
  {
    try
    {
      Car car = carsService.Create(carData);
      return Ok(car);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<string> Remove(int id)
  {
    try
    {
      string message = carsService.Remove(id);
      return Ok(message);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Car> Update(int id, [FromBody] Car updateData)
  {
    try
    {
      updateData.Id = id;
      Car car = carsService.Update(updateData);
      return Ok(car);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
