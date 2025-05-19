namespace SafeVillage.VillageModule.Exceptions;
internal class NumberOfInhabitantsIsGreaterThanHouseCapacityException(string name, int capacity, int numberOfInhabitants) 
    : Exception($"name: {name} capacity: {capacity} numberOfInhabitants: {numberOfInhabitants}");
