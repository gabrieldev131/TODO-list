# Etapa 1: Build da aplicação usando o SDK do .NET 10
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia o arquivo do projeto e restaura as dependências
COPY ["backend/TodoList.Api.csproj", "./"]
RUN dotnet restore "TodoList.Api.csproj"

# Copia o resto do código e compila
COPY backend/ .
RUN dotnet publish "TodoList.Api.csproj" -c Release -o /app/publish

# Etapa 2: Imagem final apenas com o Runtime (mais leve)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define a porta padrão que o Render espera
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "TodoList.Api.dll"]