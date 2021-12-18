#!/bin/sh

# wait for PSQL server to start
sleep 5
cd backend  
# prepare init migration
dotnet ResortForecaster.Api.dll "python3 manage.py makemigrations"  
# migrate db, so we have the latest db schema
echo HHHHHHHHHHHHHEEEEEEEEEEEEEEEEELLLLLLLLLLLLLLLLLOOOOOOOOOOOOOOOOOOOOOWORLDHHHHHHHHHHHHHEEEEEEEEEEEEEEEEELLLLLLLLLLLLLLLLLOOOOOOOOOOOOOOOOOOOOOWORLD "python3 manage.py migrate"  
