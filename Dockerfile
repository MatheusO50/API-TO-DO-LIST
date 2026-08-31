FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

WORKDIR /app

EXPOSE 5280

ENV ASPNETCORE_URLS=http://+:5280

USER app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG Configuration=Release

WORKDIR /src

COPY ["To_Do_List.csproj", "./"]

RUN dotnet restore "To_Do_List.csproj"

COPY . .

RUN dotnet build "To_Do_List.csproj" -c $Configuration -o /app/build

FROM build AS publish

ARG Configuration=Release

RUN dotnet publish "To_Do_List.csproj" \
    -c $Configuration \
    -o /app/publish \
    /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "To_Do_List.dll"]