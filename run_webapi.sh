#!/bin/sh

# set variables
CSPROJ="./src/ODataSample.WebApi/ODataSample.WebApi.csproj"

# run .NET application
dotnet run --project "$CSPROJ" -c Release
