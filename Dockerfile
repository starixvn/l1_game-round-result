FROM git3.nexdev.net:5050/lumi-ops/docker-images/dotnet/core/sdk:3.1 AS builder

WORKDIR /src

COPY ./GameRoundResult/GameRoundResult.Core ./GameRoundResult.Core
COPY ./GameRoundResult/GameRoundResult.Web/GameRoundResult.Web.csproj ./GameRoundResult.Web/GameRoundResult.Web.csproj

WORKDIR /src/GameRoundResult.Web/
RUN dotnet restore -v diag

COPY ./GameRoundResult/GameRoundResult.Web/ .

RUN dotnet publish -r linux-x64 --self-contained false -o /app && echo $CACHEBUST

FROM git3.nexdev.net:5050/lumi-ops/docker-images/dotnet/core/aspnet:3.1 AS base

WORKDIR /app
COPY --from=builder /app .

ENTRYPOINT ["dotnet", "GameRoundResult.Web.dll"]