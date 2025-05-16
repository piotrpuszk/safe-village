namespace SafeVillage.Village.Exceptions;

internal class MissingCreateBuildingMethodException(string typeName)
    : Exception($"typeName: {typeName}");
