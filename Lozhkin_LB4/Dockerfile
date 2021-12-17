#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Lozhkin_LB4/Lozhkin_LB4.csproj", "Lozhkin_LB4/"]
RUN dotnet restore "Lozhkin_LB4/Lozhkin_LB4.csproj"
COPY . .
WORKDIR "/src/Lozhkin_LB4"
RUN dotnet build "Lozhkin_LB4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lozhkin_LB4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lozhkin_LB4.dll"]