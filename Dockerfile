FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["TodoList.Api.csproj", "./"]
RUN dotnet restore "TodoList.Api.csproj"
COPY . .
RUN dotnet publish "TodoList.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TodoList.Api.dll"]