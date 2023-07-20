#!/bin/bash

set -e

until dotnet Application.dll seed; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec dotnet Application.dll
