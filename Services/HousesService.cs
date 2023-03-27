namespace sharpList.Services
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sharpList.Models;

public class HousesService
    {
        
        private readonly HousesRepository _houseRepository;

    public HousesService(HousesRepository houseRepository)
    {
        _houseRepository = houseRepository;
    }


    internal House editHouse(House update)
    {
        House house = this.getHouseById(update.id);
        house.bedrooms = update.bedrooms != null ? update.bedrooms : house.bedrooms;
        house.bathrooms = update.bathrooms != null ? update.bathrooms : house.bathrooms;
        house.floors = update.floors != null ? update.floors : house.floors;
        int rows = _houseRepository.editHouse(house);
        if(rows < 1) throw new Exception("bad house Id");
        return update;
    }

    internal string deleteHouse(int id)
    {
        int rows = _houseRepository.deleteHouse(id);
        if(rows < 1) throw new Exception("bad house Id");
        string message = "House deleted!";
        return message;
    }
    internal List<House> getAllHouses()
    {
        List<House> houses = _houseRepository.getAllHouses();
        return houses;
    }


    internal House postHouse(House houseData)
    {
        House house = _houseRepository.postHouse(houseData);
        return house;
    }
    internal House getHouseById(int houseId)
    {
        House house = _houseRepository.getHouseById(houseId);
        if(house == null)throw new Exception("bad house id");
        return house;
    }
    }
}