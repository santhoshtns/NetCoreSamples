FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CoreAuth/CoreAuth.csproj", "CoreAuth/"]
RUN dotnet restore "CoreAuth/CoreAuth.csproj"
COPY . .
WORKDIR "/src/CoreAuth"
RUN dotnet build "CoreAuth.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CoreAuth.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreAuth.dll"]