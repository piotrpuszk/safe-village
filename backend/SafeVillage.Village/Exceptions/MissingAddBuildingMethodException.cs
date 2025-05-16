namespace SafeVillage.Village.Exceptions;
internal class MissingAddBuildingMethodException(string typeName)
    : Exception($"typeName: {typeName}");
