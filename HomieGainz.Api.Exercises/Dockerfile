#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomieGainz.Api.Exercises/HomieGainz.Api.Exercises.csproj", "HomieGainz.Api.Exercises/"]
COPY ["HomieGainz.UserMeals/HomieGainz.ApplicationDb.csproj", "HomieGainz.UserMeals/"]
RUN dotnet restore "HomieGainz.Api.Exercises/HomieGainz.Api.Exercises.csproj"
COPY . .
WORKDIR "/src/HomieGainz.Api.Exercises"
RUN dotnet build "HomieGainz.Api.Exercises.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomieGainz.Api.Exercises.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomieGainz.Api.Exercises.dll"]