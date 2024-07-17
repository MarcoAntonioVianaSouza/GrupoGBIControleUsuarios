#FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build 
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore GrupoGBIControleUsuarios.Domain.csproj

#COPY . ./
#RUN dotnet publish GrupoGBIControleUsuarios.Domain.csproj -c Release -o out

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

#WORKDIR /app

#COPY --from=build /app/out .

#ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.Domain.dll"]

#------------------ -------------------------------- ----------------------------#
#------------------ MONTANDO AMBIENTE DOCKER-COMPOSE --------------------------- #
#------------------ -------------------------------- ----------------------------#
FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
WORKDIR /app
# copy csproj and restore as distinct layers

COPY GrupoGBIControleUsuarios.Domain/GrupoGBIControleUsuarios.Domain.csproj ./
RUN dotnet restore GrupoGBIControleUsuarios.Domain.csproj

COPY GrupoGBIControleUsuarios.Application/GrupoGBIControleUsuarios.Application.csproj ./
RUN dotnet restore GrupoGBIControleUsuarios.Application.csproj

COPY GrupoGBIControleUsuarios.Infra.Data/GrupoGBIControleUsuarios.Infra.Data.csproj ./
RUN dotnet restore GrupoGBIControleUsuarios.Infra.Data.csproj

COPY GrupoGBIControleUsuarios.Infra.IoC/GrupoGBIControleUsuarios.Infra.IoC.csproj ./
RUN dotnet restore GrupoGBIControleUsuarios.Infra.IoC.csproj

COPY GrupoGBIControleUsuarios.API/GrupoGBIControleUsuarios.API.csproj ./
RUN dotnet restore GrupoGBIControleUsuarios.API.csproj

COPY . ./
RUN dotnet publish GrupoGBIControleUsuarios.Domain/GrupoGBIControleUsuarios.Domain.csproj -c Release -o out
RUN dotnet publish GrupoGBIControleUsuarios.Application/GrupoGBIControleUsuarios.Application.csproj -c Release -o out
RUN dotnet publish GrupoGBIControleUsuarios.Infra.Data/GrupoGBIControleUsuarios.Infra.Data.csproj -c Release -o out
RUN dotnet publish GrupoGBIControleUsuarios.Infra.IoC/GrupoGBIControleUsuarios.Infra.IoC.csproj -c Release -o out
RUN dotnet publish GrupoGBIControleUsuarios.API/GrupoGBIControleUsuarios.API.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.API.dll"]
