namespace SafeVillage.Village.Exceptions;

internal class MissingDeleteBuildingMethodException(string typeName)
    : Exception($"typeName: {typeName}");
