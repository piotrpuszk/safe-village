using MediatR;

namespace SafeVillage.WorldGeneratorModule;
internal record GenerateCommand(int Width, int Height) : IRequest;
