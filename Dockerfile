FROM registry.nexdev.net:5050/docker/dotnet/core/sdk:5.0.102-ca-patch-buster-slim AS builder

WORKDIR /src

COPY ./GameRoundResult.Core ./GameRoundResult.Core
COPY ./GameRoundResult.Web/GameRoundResult.Web.csproj ./GameRoundResult.Web/GameRoundResult.Web.csproj

WORKDIR /src/GameRoundResult.Web/
RUN dotnet restore -v n

COPY ./GameRoundResult.Web/ .

RUN dotnet publish -r linux-x64 --self-contained false -o /app && echo $CACHEBUST

FROM registry.nexdev.net:5050/docker/dotnet/core/aspnet:5.0-buster-slim AS base

WORKDIR /app
COPY --from=builder /app .

ENTRYPOINT ["dotnet", "GameRoundResult.Web.dll"]


